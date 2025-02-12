﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WoTB_Voice_Mod_Creater.Wwise_Class.BNK_To_Wwise_Project
{
    public enum CAkType
    {
        CAkLayerCntr,
        CAkActorMixer,
        CAkRanSeqCntr,
        CAkSwitchCntr,
        CAkSound
    }
    //CAk*の共通の情報を保存するクラス
    public class BNK_Relation
    {
        public string Name { get; set; }
        public CAkType Type { get; private set; }
        public string GUID { get; private set; }
        public uint My { get; private set; }
        public uint Parent { get; private set; }
        public int Line { get; private set; }
        public BNK_Relation(CAkType My_Type, string GUID, uint My_Short_ID, uint Parent_Short_ID, int Type_Name_Line)
        {
            Name = My_Short_ID.ToString();
            Type = My_Type;
            this.GUID = GUID;
            My = My_Short_ID;
            Parent = Parent_Short_ID;
            Line = Type_Name_Line;
        }
    }
    public class RTPC_Relation
    {
        //Init.bnkから取得できるもののみprivate setが記述されています
        public string Name { get; set; }
        public string Type { get; private set; }
        public string Param { get; private set; }
        public string GUID { get; private set; }
        public uint ShortID { get; private set; }
        public double Default_Value { get; private set; }
        public double Min_Value { get; set; }
        public double Max_Value { get; set; }
        public double RampUP { get; private set; }
        public double RampDown { get; private set; }
        public RTPC_Relation(uint ShortID, string Type, string Param, double Default_Value, double RampUP, double RampDown)
        {
            this.ShortID = ShortID;
            this.Type = Type;
            this.Param = Param;
            this.Default_Value = Default_Value;
            this.RampUP = RampUP;
            this.RampDown = RampDown;
            GUID = Guid.NewGuid().ToString().ToUpper(); ;
        }
    }
    //CAkSoundの情報を保存するクラス
    public class CAkSound
    {
        public string Language { get; private set; }
        public uint ShortID { get; private set; }
        public CAkSound(string Language, uint ShortID)
        {
            this.Language = Language;
            this.ShortID = ShortID;
        }
    }
    //プロパティの保存形式(上から小数、大きい整数、小さい整数, bool(boolという名前は言語の仕様上使えないのでbooleanを使用))
    public enum Property_Type
    {
        Real64,
        int32,
        int16,
        boolean
    }
    public class BNK_Info
    {
        //Init.bnkの情報を保存
        public static List<List<string>> Master_Audio_Bus_List = new List<List<string>>();
        //解析した内容を行に分けてすべて記録
        public static List<string> Read_All = new List<string>();
        //↑の内容から、イベントID、そのIDの行、イベント形式(RandomコンテナやSwitchコンテナなど)のみを抽出
        public static List<List<string>> ID_Line = new List<List<string>>();
        //BNK内の親子関係を保存
        public static List<BNK_Relation> Relation = new List<BNK_Relation>();
        //Actor_Audioのプロジェクトファイル
        public static List<string> Actor_Mixer_Hierarchy_Project = new List<string>();
        //再現するActor_MixerのShortIDがある行を保存
        public static List<Actor_Mixer_Info> Actor_Mixer_Child_Line = new List<Actor_Mixer_Info>();
        //Init.bnkを一行ずつ保存
        public static List<string> Init_Read_All = new List<string>();
        //RTPCの情報を保存
        public static List<RTPC_Relation> RTPC_Info = new List<RTPC_Relation>();
        //Attenuationsの情報を保存
        public static List<Attenuation_Relation> Attenuation_Info = new List<Attenuation_Relation>();
        //CAkSoundの情報を保存
        public static List<CAkSound> CAkSound_Info = new List<CAkSound>();
        //bnkファイルからサウンドを取り出す用
        public static List<Wwise_File_Extract_V2> BNK_File = new List<Wwise_File_Extract_V2>();
        //pckファイルからサウンドを取り出す用
        public static List<Wwise_File_Extract_V1> PCK_File = new List<Wwise_File_Extract_V1>();
        //RTPCの親のGUIDを設定(値を変更するものではないためreadonlyにしています)
        public static readonly string Parent_RTPC_WorkUnit = Guid.NewGuid().ToString().ToUpper();
        //プロジェクトにはサウンドが設定されているが、.bnkや.pck内には存在しないファイルたち
        public static List<string> Add_Empty_Wav_Files = new List<string>();
    }
    public class BNK_To_Wwise_Projects
    {
        Actor_Mixer Actor_Mixer_Project = new Actor_Mixer();
        int Now_Extract_File_Count = 0;
        bool IsSelected = false;
        Random r = new Random();
        //解析するファイルが1つのみの場合
        public BNK_To_Wwise_Projects(string Init_File, string BNK_File, string PCK_File = null, string SoundbanksInfo = null, bool IsNoSoundInfo = false)
        {
            List<string> BNK_Files = new List<string>();
            BNK_Files.Add(BNK_File);
            if (PCK_File != null)
            {
                List<string> PCK_Files = new List<string>();
                PCK_Files.Add(PCK_File);
                BNK_To_Wwise_Projects_Init(Init_File, BNK_Files, PCK_Files, SoundbanksInfo, IsNoSoundInfo);
            }
            else
                BNK_To_Wwise_Projects_Init(Init_File, BNK_Files, null, SoundbanksInfo, IsNoSoundInfo);
        }
        //解析するファイルが複数存在する場合
        public BNK_To_Wwise_Projects(string Init_File, List<string> BNK_File, List<string> PCK_File = null, string SoundbanksInfo = null, bool IsNoSoundInfo = false)
        {
            if (PCK_File != null && PCK_File.Count > 0)
            {
                BNK_To_Wwise_Projects_Init(Init_File, BNK_File, PCK_File, SoundbanksInfo, IsNoSoundInfo);
            }
            else
                BNK_To_Wwise_Projects_Init(Init_File, BNK_File, null, SoundbanksInfo, IsNoSoundInfo);
        }
        //.bnkファイルを解析
        public void BNK_To_Wwise_Projects_Init(string Init_File, List<string> BNK_File, List<string> PCK_File = null, string SoundbanksInfo = null, bool IsNoSoundInfo = false)
        {
            if (Init_File == null || BNK_File == null)
                return;
            if (!File.Exists(Init_File) || !File.Exists(BNK_File[0]))
                return;
            if (PCK_File != null && !File.Exists(PCK_File[0]))
                return;
            if (SoundbanksInfo != null && !File.Exists(SoundbanksInfo))
                return;
            string Temp_Name_01 = Sub_Code.Get_Time_Now(DateTime.Now, "-", 1, 6);
            Sub_Code.BNK_Parse_To_XML(Init_File, Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name_01);
            BNK_Info.Init_Read_All.AddRange(File.ReadAllLines(Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name_01 + ".xml"));
            File.Delete(Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name_01 + ".xml");
            int Start_Line = -1;
            for (int Number = 0; Number < BNK_Info.Init_Read_All.Count; Number++)
            {
                if (BNK_Info.Init_Read_All[Number].Contains("<list name=\"pRTPCMgr\""))
                {
                    Start_Line = Number;
                    break;
                }
            }
            if (Start_Line != -1)
            {
                for (int Number = Start_Line; Number < BNK_Info.Init_Read_All.Count; Number++)
                {
                    if (BNK_Info.Init_Read_All[Number].Contains("<object name=\"RTPCRamping\""))
                        Init_Get_RTPC_Info(Number + 1);
                    if (BNK_Info.Init_Read_All[Number].Contains("</list>"))
                        break;
                }
            }
            List<uint> ShortIDs = new List<uint>();
            for (int Number = 0; Number < BNK_File.Count; Number++)
            {
                string Temp_Name = r.Next(0, 10000).ToString();
                Sub_Code.BNK_Parse_To_XML(BNK_File[Number], Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name);
                //解析に失敗していたら終了
                if (!File.Exists(Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name + ".xml"))
                {
                    IsSelected = false;
                    return;
                }
                string line;
                //内容をListに追加
                StreamReader file = new StreamReader(Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name + ".xml");
                while ((line = file.ReadLine()) != null)
                {
                    BNK_Info.Read_All.Add(line);
                    //この文字が含まれていたらイベントやコンテナ確定
                    if (line.Contains("type=\"sid\" name=\"ulID\" value=\"") || line.Contains("type=\"sid\" name=\"ulStateID\" value=\""))
                    {
                        List<string> ID_Line_Tmp = new List<string>();
                        //イベントIDを取得
                        string strValue = line.Remove(0, line.IndexOf("value=\"") + 7);
                        uint strValue_1 = uint.Parse(strValue.Remove(strValue.LastIndexOf("\"")));
                        if (ShortIDs.Contains(strValue_1))
                            continue;
                        ShortIDs.Add(strValue_1);
                        //イベントの内容を取得(CASoundやCAkRanSeqCntrなど)
                        string strValue2 = BNK_Info.Read_All[BNK_Info.Read_All.Count - 4].Remove(0, BNK_Info.Read_All[BNK_Info.Read_All.Count - 4].IndexOf("name=\"") + 6);
                        strValue2 = strValue2.Remove(strValue2.IndexOf("index") - 2);
                        ID_Line_Tmp.Add(strValue_1.ToString());
                        //イベントの行
                        ID_Line_Tmp.Add((BNK_Info.Read_All.Count - 1).ToString());
                        ID_Line_Tmp.Add(strValue2);
                        BNK_Info.ID_Line.Add(ID_Line_Tmp);
                        if (strValue2 == "CAkRanSeqCntr" || strValue2 == "CAkSwitchCntr" || strValue2 == "CAkSound" || strValue2 == "CAkLayerCntr" || strValue2 == "CAkActorMixer")
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                BNK_Info.Read_All.Add(line);
                                if (line.Contains("name=\"DirectParentID\""))
                                {
                                    string strValue3 = line.Remove(0, line.IndexOf("value=\"") + 7);
                                    strValue3 = strValue3.Remove(strValue3.LastIndexOf("\""));
                                    string My_GUID = Guid.NewGuid().ToString().ToUpper();
                                    CAkType Type;
                                    if (Enum.TryParse<CAkType>(strValue2, out Type))
                                        BNK_Info.Relation.Add(new BNK_Relation(Type, My_GUID, strValue_1, uint.Parse(strValue3), (BNK_Info.Read_All.Count - 2)));
                                    break;
                                }
                            }
                        }
                    }
                }
                file.Close();
                file.Dispose();
                //生成されたxmlファイルは使用しないので消しておく
                File.Delete(Voice_Set.Special_Path + "/Wwise_Parse/" + Temp_Name + ".xml");
            }
            Attenuations.Init();
            Switch.Init();
            State.Init();
            Master_Mixer.Init();
            Events.Init();
            BlendTracks.Init();
            if (IsNoSoundInfo)
                BNK_To_Wwise_Project.SoundbanksInfo.Init();
            else if (SoundbanksInfo != null)
                BNK_To_Wwise_Project.SoundbanksInfo.Init(SoundbanksInfo);
            foreach (string BNK_Now in BNK_File)
                BNK_Info.BNK_File.Add(new Wwise_File_Extract_V2(BNK_Now));
            if (PCK_File != null)
                foreach (string PCK_Now in PCK_File)
                    BNK_Info.PCK_File.Add(new Wwise_File_Extract_V1(PCK_Now));
            IsSelected = true;
        }
        public async Task ShortID_To_Name(TextBlock Message_T)
        {
            await SoundbanksInfo.Generate_Name(Message_T);
        }
        //value=のあとの数字を取得
        string Get_Property_Value(string Read_Line)
        {
            string strValue = Read_Line.Substring(Read_Line.IndexOf("value=\"") + 7);
            return strValue.Substring(0, strValue.IndexOf("\""));
        }
        //RTPC情報をリストに保存
        void Init_Get_RTPC_Info(int Start_Line)
        {
            string Temp_Type = BNK_Info.Init_Read_All[Start_Line + 2];
            Temp_Type = Temp_Type.Substring(Temp_Type.IndexOf('[') + 1);
            Temp_Type = Temp_Type.Substring(0, Temp_Type.IndexOf(']'));
            string Temp_Param = BNK_Info.Init_Read_All[Start_Line + 5];
            Temp_Param = Temp_Param.Substring(Temp_Param.IndexOf('[') + 1);
            Temp_Param = Temp_Param.Substring(0, Temp_Param.IndexOf(']'));
            BNK_Info.RTPC_Info.Add(new RTPC_Relation(
                uint.Parse(Get_Property_Value(BNK_Info.Init_Read_All[Start_Line])), Temp_Type, Temp_Param,
                double.Parse(Get_Property_Value(BNK_Info.Init_Read_All[Start_Line + 1])),
                double.Parse(Get_Property_Value(BNK_Info.Init_Read_All[Start_Line + 3])),
                double.Parse(Get_Property_Value(BNK_Info.Init_Read_All[Start_Line + 4]))
                ));
        }
        //メモリを解放
        public void Clear()
        {
            for (int Number = 0; Number < BNK_Info.Master_Audio_Bus_List.Count; Number++)
                BNK_Info.Master_Audio_Bus_List[Number].Clear();
            for (int Number = 0; Number < BNK_Info.ID_Line.Count; Number++)
                BNK_Info.ID_Line[Number].Clear();
            BNK_Info.Read_All.Clear();
            BNK_Info.Master_Audio_Bus_List.Clear();
            BNK_Info.Actor_Mixer_Hierarchy_Project.Clear();
            BNK_Info.ID_Line.Clear();
            BNK_Info.Actor_Mixer_Child_Line.Clear();
            BNK_Info.Relation.Clear();
            BNK_Info.Init_Read_All.Clear();
            BNK_Info.Attenuation_Info.Clear();
            BNK_Info.RTPC_Info.Clear();
            BNK_Info.Add_Empty_Wav_Files.Clear();
            BNK_Info.CAkSound_Info.Clear();
            Events.Event_Info.Clear();
            Events.Event_ShortID.Clear();
            Switch.Switch_Info.Clear();
            State.State_All_Info.Clear();
            State.State_Child_Info.Clear();
            State.State_Value_Info.Clear();
            BlendTracks.Layer_Info.Clear();
            Master_Mixer.Master_Audio_Info.Clear();
            for (int Number = 0; Number < BNK_Info.BNK_File.Count; Number++)
                BNK_Info.BNK_File[Number].Bank_Clear();
            if (BNK_Info.PCK_File != null)
                for (int Number = 0; Number < BNK_Info.PCK_File.Count; Number++)
                    BNK_Info.PCK_File[Number].Pck_Clear();
            BNK_Info.BNK_File.Clear();
            BNK_Info.PCK_File.Clear();
            Actor_Mixer_Project.Clear();
        }
        public async Task<bool> Create_Project_All(string To_Dir, bool IsExtractSound, System.Windows.Controls.TextBlock Message_T)
        {
            if (!IsSelected)
                return false;
            try
            {
                if (!Directory.Exists(To_Dir))
                    Directory.CreateDirectory(To_Dir);
                await Actor_Mixer_Project.Get_Actor_Mixer_Hierarchy(To_Dir + "\\Actor-Mixer Hierarchy\\Default Work Unit.wwu", IsExtractSound, Message_T);
                Message_T.Text = "'Game Parameter'を作成しています...";
                await Task.Delay(50);
                Game_Parameter.Create(To_Dir + "\\Game Parameters\\SRTTbacon.wwu");
                Message_T.Text = "'Attenuations'を作成しています...";
                await Task.Delay(50);
                Attenuations.Create(To_Dir + "\\Attenuations\\Default Work Unit.wwu");
                Message_T.Text = "Master Mixerを作成しています...";
                await Task.Delay(50);
                Master_Mixer.Create(To_Dir + "\\Master-Mixer Hierarchy\\Default Work Unit.wwu");
                Message_T.Text = "Switchを作成しています...";
                await Task.Delay(50);
                Switch.Create(To_Dir + "\\Switches\\Default Work Unit.wwu");
                Message_T.Text = "Stateを作成しています...";
                await Task.Delay(50);
                State.Create(To_Dir + "\\States\\Default Work Unit.wwu");
                await Events.Set_Name(Message_T);
                Events.Create(To_Dir + "\\Events\\SRTTbacon.wwu");
                Message_T.Text = "SoundBanksを作成しています...";
                await Task.Delay(50);
                SoundBanks.Create(To_Dir + "\\SoundBanks\\Default Work Unit.wwu");
                Message_T.Text = "必要なファイルをコピーしています...";
                await Task.Delay(50);
                Create_Project_Directory(To_Dir);
                if (IsExtractSound)
                {
                    Message_T.Text = "サウンドファイルを抽出しています...";
                    await Task.Delay(50);
                    Now_Extract_File_Count = 0;
                    int Max_Extract_File_Count = BNK_Info.CAkSound_Info.Count;
                    if (BNK_Info.PCK_File != null && BNK_Info.PCK_File.Count > 0)
                        Max_Extract_File_Count += BNK_Info.CAkSound_Info.Count;
                    List<string> OGG_List = null;
                    bool IsEnd = false;
                    Task Run = Task.Run(() =>
                    {
                        OGG_List = Extract_WEM_To_Dir(To_Dir);
                        IsEnd = true;
                    });
                    while (!IsEnd)
                    {
                        Message_T.Text = "サウンドファイルを抽出しています...\n進捗:" + Now_Extract_File_Count + " / " + Max_Extract_File_Count;
                        await Task.Delay(1000);
                    }
                    Message_T.Text = ".wav形式に変換しています...";
                    await Class.Multithread.Convert_Ogg_To_Wav(OGG_List, true);
                    OGG_List.Clear();
                }
                return true;
            }
            catch (Exception e)
            {
                Sub_Code.Error_Log_Write(e.Message);
                return false;
            }
        }
        void Create_Project_Directory(string To_Dir)
        {
            try
            {
                if (!Directory.Exists(To_Dir))
                    Directory.CreateDirectory(To_Dir);
                File.Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Actor-Mixer Hierarchy\\Factory Motion.wwu", To_Dir + "\\Actor-Mixer Hierarchy\\Factory Motion.wwu", true);
                File.Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Actor-Mixer Hierarchy\\Factory SoundSeed Air Objects.wwu", To_Dir + "\\Actor-Mixer Hierarchy\\Factory SoundSeed Air Objects.wwu", true);
                File.Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Actor-Mixer Hierarchy\\Factory Synth One.wwu", To_Dir + "\\Actor-Mixer Hierarchy\\Factory Synth One.wwu", true);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Audio Devices", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Control Surface Sessions", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Conversion Settings", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Dynamic Dialogue", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Effects", To_Dir);
                File.Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Events\\Default Work Unit.wwu", To_Dir + "\\Events\\Default Work Unit.wwu", true);
                File.Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Game Parameters\\Default Work Unit.wwu", To_Dir + "\\Game Parameters\\Default Work Unit.wwu", true);
                Directory.CreateDirectory(To_Dir + "\\GeneratedSoundBanks\\Windows");
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Interactive Music Hierarchy", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Mixing Sessions", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Modulators", To_Dir);
                Directory.CreateDirectory(To_Dir + "\\Originals\\SFX");
                Directory.CreateDirectory(To_Dir + "\\Originals\\Voices\\English(US)");
                Directory.CreateDirectory(To_Dir + "\\Originals\\Voices\\ja");
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Presets", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Queries", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Soundcaster Sessions", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Triggers", To_Dir);
                Sub_Code.Directory_Copy(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Virtual Acoustics", To_Dir);
                Sub_Code.Create_WAV(Voice_Set.Special_Path + "\\Wwise\\Add_Empty_WAV_File_Temp.wav", 1.0);
                foreach (string To_File in BNK_Info.Add_Empty_Wav_Files)
                    if (!File.Exists(To_Dir + To_File))
                        File.Copy(Voice_Set.Special_Path + "\\Wwise\\Add_Empty_WAV_File_Temp.wav", To_Dir + To_File);
                File.Delete(Voice_Set.Special_Path + "\\Wwise\\Add_Empty_WAV_File_Temp.wav");
                List<string> Project_Main = new List<string>();
                List<string> Game_Parameter = new List<string>();
                Project_Main.AddRange(File.ReadAllLines(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\WoTB_Sound_Mod.wproj"));
                Game_Parameter.AddRange(File.ReadAllLines(Voice_Set.Special_Path + "\\Wwise\\WoTB_Sound_Mod\\Game Parameters\\Default Work Unit.wwu"));
                Project_Main[3] = "        <Project Name=\"WoTB_Generate_Projects\" ID=\"{" + Guid.NewGuid().ToString().ToUpper() + "}\">";
                for (int Number = 0; Number < Project_Main.Count; Number++)
                {
                    string a = Project_Main[Number];
                    if (a.Contains("<PhysicalFolder Path=\"Events\\Hanger_BGM\">") || a.Contains("<PhysicalFolder Path=\"Events\\LoadBGM\">") || a.Contains("<WorkUnit Name=\"LoadBGM\""))
                    {
                        for (int Number_01 = 0; Number_01 < 3; Number_01++)
                        {
                            Project_Main.RemoveAt(Number);
                            Number--;
                        }
                    }
                    if (a.Contains("</PhysicalFolderList>"))
                    {
                        for (int Number_01 = 0; Number_01 < 4; Number_01++)
                            Project_Main.RemoveAt(Number);
                        break;
                    }
                }
                Project_Main.Add("				<PhysicalFolder Path=\"Events\">");
                Project_Main.Add("					<WorkUnit Name=\"SRTTbacon\" ID=\"{" + Events.Event_Parent_UUID + "}\" PersistMode=\"Standalone\"/>");
                Project_Main.Add("				</PhysicalFolder>");
                Project_Main.Add("				<PhysicalFolder Path=\"Game Parameters\">");
                Project_Main.Add("					<WorkUnit Name=\"SRTTbacon\" ID=\"{" + BNK_Info.Parent_RTPC_WorkUnit + "}\" PersistMode=\"Standalone\"/>");
                Project_Main.Add("				</PhysicalFolder>");
                Project_Main.Add("			</PhysicalFolderList>");
                Project_Main.Add("		</Project>");
                Project_Main.Add("	</ProjectInfo>");
                Project_Main.Add("</WwiseDocument>");
                for (int Number = 0; Number < Game_Parameter.Count; Number++)
                {
                    string a = Game_Parameter[Number];
                    if (a.Contains("<WorkUnit Name=\"UI\"") || a.Contains("<WorkUnit Name=\"Hanger\""))
                    {
                        Game_Parameter.RemoveAt(Number);
                        Number--;
                    }
                }
                File.WriteAllLines(To_Dir + "\\WoTB_Generate_Projects.wproj", Project_Main);
                File.WriteAllLines(To_Dir + "\\Game Parameters\\Default Work Unit.wwu", Game_Parameter);
                Project_Main.Clear();
                Game_Parameter.Clear();
            }
            catch (Exception e)
            {
                Sub_Code.Error_Log_Write(e.Message);
            }
        }
        public List<string> Extract_WEM_To_Dir(string To_Project_Dir)
        {
            if (!IsSelected)
                return new List<string>();
            List<string> Temp_List = new List<string>();
            foreach (CAkSound Temp in BNK_Info.CAkSound_Info)
            {
                if (Temp.Language == "SFX")
                {
                    for (int Number = 0; Number < BNK_Info.BNK_File.Count; Number++)
                    {
                        BNK_Info.BNK_File[Number].Wwise_Extract_To_Ogg_File(Temp.ShortID, To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg", true);
                        if (!Temp_List.Contains(To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg"))
                            Temp_List.Add(To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg");
                    }
                }
                else
                {
                    for (int Number = 0; Number < BNK_Info.BNK_File.Count; Number++)
                    {
                        BNK_Info.BNK_File[Number].Wwise_Extract_To_Ogg_File(Temp.ShortID, To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg", true);
                        if (!Temp_List.Contains(To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg"))
                            Temp_List.Add(To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg");
                    }
                }
                Now_Extract_File_Count++;
            }
            if (BNK_Info.PCK_File != null)
            {
                foreach (CAkSound Temp in BNK_Info.CAkSound_Info)
                {
                    if (Temp.Language == "SFX")
                    {
                        for (int Number = 0; Number < BNK_Info.PCK_File.Count; Number++)
                        {
                            BNK_Info.PCK_File[Number].Wwise_Extract_To_Ogg_File(Temp.ShortID, To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg", true);
                            if (!Temp_List.Contains(To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg"))
                                Temp_List.Add(To_Project_Dir + "\\Originals\\SFX\\" + Temp.ShortID + ".ogg");
                        }
                    }
                    else
                    {
                        for (int Number = 0; Number < BNK_Info.PCK_File.Count; Number++)
                        {
                            BNK_Info.PCK_File[Number].Wwise_Extract_To_Ogg_File(Temp.ShortID, To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg", true);
                            if (!Temp_List.Contains(To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg"))
                                Temp_List.Add(To_Project_Dir + "\\Originals\\Voices\\" + Temp.Language + "\\" + Temp.ShortID + ".ogg");
                        }
                    }
                    Now_Extract_File_Count++;
                }
            }
            return Temp_List;
        }
    }
}