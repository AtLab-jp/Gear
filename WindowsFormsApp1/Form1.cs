using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static int var_count = 0;
        public static string[] var_contents = new string[128];
        public static string[] var_class = new string[128];
        public static string[] var_value = new string[128];
        public static bool[] var_init = new bool[128];
        public static int[,] Lines = new int[Max,10];

        public static bool highlight = false;

        Form2 Code;
        Printf pf;
        If ifc;
        Scanf scc;
        For forc;
        Sleep sl;
        While wh;
        Form3 fm3;
        Sub subc;
        printf説明 pfs;
        if説明 ifs;
        scanf説明 scs;
        for説明 fors;
        while説明 whs;
        switchcase説明 sws;           //使用するフォームの宣言
        getchar説明 gets;
        substitute説明 subs;
        sleep説明 sles;
        Exit説明 exits;
        rand説明 rands;
        EndProcessing end;
        Pass ps;
        Debug db;
        Form4 Code2;
        rand rand;
        getchar getchar;

        public const int Max = 256;             
        private System.Windows.Forms.PictureBox[] Icons;    //ピクチャーボックスの配列
        int disp_icon=0;            //表示されているアイコンの数・次に生成されるアイコンの番号
        int mousex;                 //マウスのX座標
        int mousey;                 //マウスのY座標
        int m = 1;                  //右クリック1or2の判定
        int FirstClicked;           //一回目のクリック(配列の番号）
        int Controlling;            //ドラッグ・クリックなど操作中のアイコン番号
        int Clickt;                 
        int id;                     //入力フォームが表示されているアイコン番号
        int lr;                     //左ダブルクリック判定
        int Language = Properties.Settings.Default.Language;                     //言語設定用
        int delete = 0;             //ワイヤ消去用
        int NowMax = 0;
        int cfrom = -1;
        int cto = -1;
        int error = 0;

        //各アイコンの形を指定
        Point[] diamond = { new Point(50,0), new Point(100, 25),new Point(50, 50), new Point(0, 25)};
        Point[] rectangle = { new Point(0, 0), new Point(100, 0), new Point(100, 50), new Point(0, 50) };
        Point[] trapezoid = { new Point(25, 0), new Point(75, 0), new Point(100, 50), new Point(0, 50) };
        Point[] r_trapezoid = { new Point(0, 0), new Point(100, 0), new Point(75, 50), new Point(25, 50) };
        byte[] types4 = {(byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line,
                        (byte) System.Drawing.Drawing2D.PathPointType.Line};

        private string FileName = "";


        public struct IconOption
        {
            public bool enable;
            public double x;       //座標
            public double y;
            public double xx;      //座標の偏差
            public double yy;      
            public bool movable;   //動作可能かどうか
            public int connectto;  //接続先
            public int connectto2; //ifなどの分岐用
            public int type;       //アイコンの種類
            //1:printf 2:if
            public int a;          //汎用変数(if用)
            public string text1;
            public string text2;
            public string text3;
            public int number1;
            public int number2;
            public int mode;       //文字列を表示するか変数の中身を表示するか
            public bool Check1;    //フォーム内でチェックがあるか否か
            public int LineCount;
        };

        public static IconOption[] IconElements = new IconOption[Max];    //アイコンの要素
        public static IconOption StartElements;
        public static IconOption EndElements;

        [Serializable]
        public class test
        {
            public int disp_Icon;
            public int NowMax;
            public int var_count;

            public bool[] enable = new bool[Max];
            public double[] x = new double[Max];
            public double[] y = new double[Max];
            public double[] xx = new double[Max];
            public double[] yy = new double[Max];
            public bool[] movable = new bool[Max];
            public int[] connectto = new int[Max];
            public int[] connectto2 = new int[Max];
            public int[] type = new int[Max];
            public int[] a = new int[Max];
            public string[] text1 = new string[Max];
            public string[] text2 = new string[Max];
            public string[] text3 = new string[Max];
            public int[] number1 = new int[Max];
            public int[] number2 = new int[Max];
            public int[] mode = new int[Max];
            public bool[] Check1 = new bool[Max];

            public bool startenable = new bool();
            public double startx = new double();
            public double starty = new double();
            public double startxx = new double();
            public double startyy = new double();
            public bool startmovable = new bool();
            public int startconnectto = new int();
            public int startconnectto2 = new int();
            public int starttype = new int();
            public int starta = new int();
            public string starttext1;
            public string starttext2;
            public string starttext3;
            public int startnumber1 = new int();
            public int startnumber2 = new int();
            public int startmode = new int();
            public bool startCheck1 = new bool();

            public bool endenable = new bool();
            public double endx = new double();
            public double endy = new double();
            public double endxx = new double();
            public double endyy = new double();
            public bool endmovable = new bool();
            public int endconnectto = new int();
            public int endconnectto2 = new int();
            public int endtype = new int();
            public int enda = new int();
            public string endtext1;
            public string endtext2;
            public string endtext3;
            public int endnumber1 = new int();
            public int endnumber2 = new int();
            public int endmode = new int();
            public bool endCheck1 = new bool();


            public string[] var_contents = new string[128];
            public string[] var_class = new string[128];
            public string[] var_value = new string[128];
            public bool[] var_init = new bool[128];

        }
        test ary = new test();

        public string printfreceive;
        public string ifreceive1;
        public string ifreceive2;
        public string ifreceive3;
        public string modereceive;
        public Form1()
        {
            InitializeComponent();
            Code = new Form2();
            Code.Owner = this;
            pf = new Printf();
            pf.Owner = this;
            ifc = new If();
            ifc.Owner = this;
            scc = new Scanf();
            scc.Owner = this;
            forc = new For();
            forc.Owner = this;
            sl = new Sleep();
            sl.Owner = this;
            wh = new While();
            wh.Owner = this;
            fm3 = new Form3();
            fm3.Owner = this;
            subc = new Sub();
            subc.Owner = this;
            pfs = new printf説明();
            pfs.Owner = this;
            ifs = new if説明();
            ifs.Owner = this;
            scs = new scanf説明();
            scs.Owner = this;
            fors = new for説明();
            fors.Owner = this;
            whs = new while説明();
            whs.Owner = this;
            sws = new switchcase説明();
            sws.Owner = this;
            gets = new getchar説明();
            gets.Owner = this;
            subs = new substitute説明();
            subs.Owner = this;
            sles = new sleep説明();
            sles.Owner = this;
            exits = new Exit説明();
            exits.Owner = this;
            rands = new rand説明();
            rands.Owner = this;
            end = new EndProcessing();
            end.Owner = this;
            ps = new Pass();
            ps.Owner = this;
            db = new Debug();
            db.Owner = this;
            Code2 = new Form4();
            Code2.Owner = this;
            rand = new rand();
            rand.Owner = this;
            getchar = new getchar();
            getchar.Owner = this;
        }
       
        //フォームのLoadイベントハンドラ
        private void Form1_Load(object sender, System.EventArgs e)
        {
            pictureBox1.Size = new Size(pictureBox1.Width,this.Height -100);
            this.Left = -10;       　//フォーム表示調節
            this.Top = 0;            
            SaveFileDialog.Filter = "テキスト文章|*.xml|すべてのファイル|*.*";    //保存可能な形式の定義
            OpenFileDialog.Filter = "テキスト文章|*.xml|すべてのファイル|*.*";
            // 「上書き保存」を無効にする
            上書き保存ToolStripMenuItem.Enabled = false;
            //ボタンコントロール配列の作成
            this.Icons = new System.Windows.Forms.PictureBox[Max];      //ボタンコントロールの配列にすでに作成されているインスタンスを代入
            Trash.Location = new Point(this.Width - Trash.Width - 30, this.Height - Trash.Height - 30);     //ゴミ箱表示場所変更
            wire_delete.Location = new Point((Trash.Left + 20),(Trash.Top -　10));    //ワイヤー消去モード表示場所変更
            for (int i = 0; i < Icons.Length; i++)
            {
                IconElements[i].x = 0;
                IconElements[i].y = 0;
                IconElements[i].movable = false;
                this.Icons[i] = new PictureBox();
                this.Icons[i].Visible = false;
                this.Icons[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(this.Icons[i]);
                StartElements.connectto = -1;
                IconElements[i].connectto = -1;
                IconElements[i].connectto2 = -1;
                IconElements[Controlling].a = 0;
                IconElements[i].number1 = 0;
                IconElements[i].enable = false;
                IconElements[i].mode = 0;
                for (int j = 0; j < 10; j++) Lines[i,j] = 0 ;
                IconElements[i].LineCount = 0;
            }
            //イベントハンドラに関連付け
            for (int i = 0; i < this.Icons.Length; i++)
            {
                this.Icons[i].MouseDown += new MouseEventHandler(this.IconDown);
                this.Icons[i].MouseUp += new MouseEventHandler(this.IconUp);
                this.Icons[i].MouseMove += new MouseEventHandler(this.Icon_MouseMove);
                this.Icons[i].DoubleClick += new EventHandler(this.Icon_Double);
                this.Icons[i].MouseWheel += new MouseEventHandler(this.Scroll);
            }
            this.StartIcon.MouseWheel += new MouseEventHandler(this.Scroll);
            this.EndIcon.MouseWheel += new MouseEventHandler(this.Scroll);
            this.panel1.MouseWheel += new MouseEventHandler(this.Scroll);
            
            if(Language==0)
            {
                英語ToolStripMenuItem.Checked = true;
                日本語ToolStripMenuItem.Checked = false;
                表示ToolStripMenuItem.Text = "View";
                説明jkToolStripMenuItem.Text = "Icons Description";
                実行ToolStripMenuItem.Text = "Run";
                保存ToolStripMenuItem.Text = "File";
                編集ToolStripMenuItem.Text = "Edit";
                設定ToolStripMenuItem.Text = "Settings";
                コードの出力ToolStripMenuItem.Text = "Code Output";
                プログラムの実行ToolStripMenuItem.Text = "Program Exection";
                ハイライトモードToolStripMenuItem.Text = "Highlights Mode";
                名前を付けて保存ToolStripMenuItem.Text = "Save As";
                上書き保存ToolStripMenuItem.Text = "Save";
                ファイルを開くToolStripMenuItem.Text = "Open";
                アイコンをリセットToolStripMenuItem.Text = "Reset";
                ラインをリセットToolStripMenuItem.Text = "Reset All Wires";
                アイコンの整列ToolStripMenuItem.Text = "Organize Icons";
                変数の管理ToolStripMenuItem.Text = "Controll Variable";
                言語設定ToolStripMenuItem.Text = "Language";
                日本語ToolStripMenuItem.Text = "Japanese";
                英語ToolStripMenuItem.Text = "English";
                ユーザーレベルToolStripMenuItem.Text = "User level";
                wire_delete.Text = "Delete Wire";
            }
            else if(Language==1)
            {
                英語ToolStripMenuItem.Checked = false;
                日本語ToolStripMenuItem.Checked = true;
                表示ToolStripMenuItem.Text = "表示";
                説明jkToolStripMenuItem.Text = "各アイコンの説明";
                実行ToolStripMenuItem.Text = "実行";
                保存ToolStripMenuItem.Text = "ファイル";
                編集ToolStripMenuItem.Text = "編集";
                設定ToolStripMenuItem.Text = "設定";
                コードの出力ToolStripMenuItem.Text = "コードの出力";
                プログラムの実行ToolStripMenuItem.Text = "プログラムの出力";
                ハイライトモードToolStripMenuItem.Text = "ハイライトモード";
                名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
                上書き保存ToolStripMenuItem.Text = "上書き保存";
                ファイルを開くToolStripMenuItem.Text = "ファイルを開く";
                アイコンをリセットToolStripMenuItem.Text = "リセット";
                ラインをリセットToolStripMenuItem.Text = "ラインをリセット";
                アイコンの整列ToolStripMenuItem.Text = "アイコンの整列";
                変数の管理ToolStripMenuItem.Text = "変数の管理";
                言語設定ToolStripMenuItem.Text = "言語設定";
                日本語ToolStripMenuItem.Text = "日本語";
                英語ToolStripMenuItem.Text = "英語";
                ユーザーレベルToolStripMenuItem.Text = "ユーザーレベル";
                wire_delete.Text = "ワイヤー消去モード";
            }
            Console.Write(Language);
        }

        private void IconDown(object sender, MouseEventArgs e) 
        {
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);    //カーソル位置の定義
            mousex = cp.X;          //カーソルX座標取得
            mousey = cp.Y;          //カーソルY座標取得
            for (int i = 0; i < this.Icons.Length; i++)     //アイコン上にカーソルがあるか
            {
                if ((mousex > this.Icons[i].Left)&&
                    (mousex < this.Icons[i].Right)&&
                    (mousey > this.Icons[i].Top)&&
                    (mousey < this.Icons[i].Bottom))
                {
                    if(this.Icons[i].Visible==true)Controlling = i;     //Controllingの更新
                }
            }
            if(highlight==false)
            {
                switch (e.Button)
                {

                    case MouseButtons.Left:
                        lr = 0;     //ダブルクリック判定変数
                        IconElements[Controlling].movable = true;
                        IconElements[Controlling].xx = mousex;
                        IconElements[Controlling].yy = mousey;
                        this.Icons[Controlling].BringToFront();
                        this.MainMenuStrip.BringToFront();
                        m = 1;
                        //Console.Write(m);
                        break;

                    case MouseButtons.Right:
                        lr = 1;
                        Clickt++;
                        if (Clickt == 1)
                        {
                            if (delete == 0)
                            {
                                m = (m + 1) % 2;
                                //Console.Write(m);
                                if (m == 0)     //一回目の右クリック
                                {
                                    FirstClicked = Controlling;
                                    if (IconElements[Controlling].type == 1) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.printf_select;
                                    if (IconElements[Controlling].a == 0 && IconElements[Controlling].type == 2) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.if_sita_select;
                                    if (IconElements[Controlling].a == 1 && IconElements[Controlling].type == 2) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.if_migi_select;
                                    if (IconElements[Controlling].type == 3) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.diamond_select;
                                    if (IconElements[Controlling].type == 4) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.scanf_select;
                                    if (IconElements[Controlling].type == 5) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.for_select;
                                    if (IconElements[Controlling].type == 6) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.for_end_select;
                                    if (IconElements[Controlling].type == 7) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.while_select;
                                    if (IconElements[Controlling].type == 8) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.getchar_select;
                                    if (IconElements[Controlling].type == 9) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.sleep_select;
                                    if (IconElements[Controlling].type == 10) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.substitute_select;
                                    if (IconElements[Controlling].type == 11) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.endup_select;
                                    if (IconElements[Controlling].type == 12) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.rand_select;
                                }
                                if (m == 1)     //二回目の右クリック
                                {
                                    if (FirstClicked == -1)     //StartIconからの二回目のクリック
                                    {
                                        StartElements.connectto = Controlling;
                                        this.StartIcon.Image = global::WindowsFormsApp1.Properties.Resources.start;
                                    }
                                    else if (Controlling == FirstClicked && IconElements[Controlling].type == 2)    //ifIconからの二回目のクリック
                                    {
                                        IconElements[Controlling].a = (IconElements[Controlling].a + 1) % 2;
                                        if (IconElements[Controlling].a == 0) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.if_sita;
                                        if (IconElements[Controlling].a == 1) this.Icons[Controlling].Image = global::WindowsFormsApp1.Properties.Resources.if_migi;
                                    }
                                    else if (Controlling == FirstClicked)
                                    {
                                        if (IconElements[FirstClicked].type == 1) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.printf;
                                        if (IconElements[FirstClicked].type == 2) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._if;
                                        if (IconElements[FirstClicked].type == 3) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.if_end;
                                        if (IconElements[FirstClicked].type == 4) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.scanf;
                                        if (IconElements[FirstClicked].type == 5) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._for;
                                        if (IconElements[FirstClicked].type == 6) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.for_end;
                                        if (IconElements[FirstClicked].type == 7) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._while;
                                        if (IconElements[FirstClicked].type == 8) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.getchar;
                                        if (IconElements[FirstClicked].type == 9) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.sleep;
                                        if (IconElements[FirstClicked].type == 10) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.substitute;
                                        if (IconElements[FirstClicked].type == 11) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.endup_image;
                                        if (IconElements[FirstClicked].type == 12) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.rand;
                                    }
                                    else if (IconElements[FirstClicked].a == 1)
                                    {
                                        IconElements[FirstClicked].connectto2 = Controlling;
                                        if (IconElements[FirstClicked].type == 2) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._if;
                                    }
                                    else
                                    {
                                        IconElements[FirstClicked].connectto = Controlling;
                                        if (IconElements[FirstClicked].type == 1) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.printf;
                                        if (IconElements[FirstClicked].type == 2) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._if;
                                        if (IconElements[FirstClicked].type == 3) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.if_end;
                                        if (IconElements[FirstClicked].type == 4) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.scanf;
                                        if (IconElements[FirstClicked].type == 5) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._for;
                                        if (IconElements[FirstClicked].type == 6) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.for_end;
                                        if (IconElements[FirstClicked].type == 7) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._while;
                                        if (IconElements[FirstClicked].type == 8) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.getchar;
                                        if (IconElements[FirstClicked].type == 9) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.sleep;
                                        if (IconElements[FirstClicked].type == 10) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.substitute;
                                        if (IconElements[FirstClicked].type == 11) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.endup_image;
                                        if (IconElements[FirstClicked].type == 12) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.rand;
                                    }
                                }
                            }
                            else
                            {
                                IconElements[Controlling].connectto = -1;
                                IconElements[Controlling].connectto2 = -1;
                            }
                            Draw();     //ライン描写
                        }

                        break;
                }

            }
            else
            {
                Code2.SendErase = "";
                for(int i=0;(i<IconElements[Controlling].LineCount);i++)
                {
                    if(Lines[Controlling, i] != 0)Code2.SendHighlight = Lines[Controlling,i].ToString();
                }
            }
        }
        private void IconUp(object sender, MouseEventArgs e)    //アイコンの削除
        {
            try
            {
                if (IconElements[Controlling].x > this.Trash.Left && IconElements[Controlling].x < this.Trash.Right &&
                    IconElements[Controlling].y > this.Trash.Top && IconElements[Controlling].y < this.Trash.Bottom)
                {
                    IconElements[Controlling].enable = false;
                    IconElements[Controlling].connectto = -1;
                    IconElements[Controlling].connectto2 = -1;
                    this.Icons[Controlling].Visible = false;
                    for (int i = 0; i < Max; i++)
                    {
                        if (IconElements[i].connectto == Controlling) IconElements[i].connectto = -1;
                        if (IconElements[i].connectto2 == Controlling) IconElements[i].connectto2 = -1;
                    }
                    if (StartElements.connectto == Controlling)
                    {
                        StartElements.connectto = -1;
                    }
                }
                if(cfrom !=-1)
                {
                    if(cfrom>=0)
                    {
                        IconElements[cfrom].connectto = cto;
                        cfrom = -1;
                        cto = -1;
                    }
                    if(cfrom==-2)
                    {
                        StartElements.connectto = cto;
                        cfrom = -1;
                        cto = -1;
                    }
                }
                IconElements[Controlling].movable = false;
                Clickt = 0;
                Draw();
            }
            catch
            {

            }
        }
        private void Icon_Double(object sender, EventArgs e)    //入力フォーム
        {
            if (lr == 0)
            {
                if (IconElements[Controlling].type == 1)
                {
                    pf.Show();
                    pf.SendMode = IconElements[Controlling].mode.ToString();
                    pf.Sendid = Controlling.ToString();
                    pf.SendDataText1 = IconElements[Controlling].text1;
                    pf.SendDataCheck1 = IconElements[Controlling].Check1.ToString();
                    pf.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 2)
                {
                    ifc.Show();
                    ifc.Sendid = Controlling.ToString();
                    ifc.SendDataText1 = IconElements[Controlling].text1;
                    ifc.SendDataText2 = IconElements[Controlling].text2;
                    ifc.SendDataInt1 = IconElements[Controlling].number1.ToString();
                    ifc.SendMode = IconElements[Controlling].mode.ToString();
                    ifc.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if(IconElements[Controlling].type == 4)
                {
                    scc.Show();
                    scc.Sendid = Controlling.ToString();
                    scc.SendDataText1 = IconElements[Controlling].text1;
                    scc.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 5)
                {
                    forc.Show();
                    forc.Sendid = Controlling.ToString();
                    forc.SendDataLanguage = Language.ToString();
                    forc.SendDataInt1 = IconElements[Controlling].number1.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 7)
                {
                    wh.Show();
                    wh.Sendid = Controlling.ToString();
                    wh.SendDataLanguage = Language.ToString();
                    wh.SendDataText1 = IconElements[Controlling].text1;
                    wh.SendDataText2 = IconElements[Controlling].text2;
                    wh.SendMode = IconElements[Controlling].mode.ToString();
                    wh.SendDataInt1 = IconElements[Controlling].number1.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 8)
                {
                    getchar.Show();
                    getchar.Sendid = Controlling.ToString();
                    getchar.SendDataLanguage = Language.ToString();
                    getchar.SendDataText1 = IconElements[Controlling].text1;
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 9)
                {
                    sl.Show();
                    sl.Sendid = Controlling.ToString();
                    sl.SendDataInt1 = IconElements[Controlling].number1.ToString();
                    sl.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 10)
                {
                    subc.Show();
                    subc.Sendid = Controlling.ToString();
                    subc.SendDataText1 = IconElements[Controlling].text1;
                    subc.SendDataText2 = IconElements[Controlling].text2;
                    subc.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 11)
                {
                    end.Show();
                    end.Sendid = Controlling.ToString();
                    end.SendDataText1 = IconElements[Controlling].text1;
                    end.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
                if (IconElements[Controlling].type == 12)
                {
                    rand.Show();
                    rand.Sendid = Controlling.ToString();
                    rand.SendDataText1 = IconElements[Controlling].text1;
                    rand.SendDataInt1 = IconElements[Controlling].number1.ToString();
                    rand.SendDataInt2 = IconElements[Controlling].number2.ToString();
                    rand.SendDataLanguage = Language.ToString();
                    id = Controlling;
                }
            }
        }
        private void CreateIcon1(object sender, MouseEventArgs e)
        {
            //画面の更新を一度止める
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();      
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.printf;
            IconElements[disp_icon].x = Icon1.Left + 150;
            IconElements[disp_icon].y = Icon1.Top + pnlContainer.Top;
             //複製したアイコンの座標を更新
            this.Icons[disp_icon].Location = 
                new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y); 
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 1;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon2(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(diamond, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources._if;
            IconElements[disp_icon].x = Icon2.Left + 150;
            IconElements[disp_icon].y = Icon2.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 2;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon3(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.scanf;
            IconElements[disp_icon].x = Icon4.Left + 150;
            IconElements[disp_icon].y = Icon4.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].yy = mousey;
            IconElements[disp_icon].type = 4;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon4(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(diamond, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.if_end;
            IconElements[disp_icon].x = Icon3.Left + 150;
            IconElements[disp_icon].y = Icon3.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].yy = mousey;
            IconElements[disp_icon].type = 3;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon5(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(trapezoid, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources._for;
            IconElements[disp_icon].x = Icon5.Left + 150;
            IconElements[disp_icon].y = Icon5.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 5;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon6(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(r_trapezoid, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.for_end;
            IconElements[disp_icon].x = Icon6.Left + 150;
            IconElements[disp_icon].y = Icon6.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 6;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon7(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                 new System.Drawing.Drawing2D.GraphicsPath(trapezoid, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources._while;
            IconElements[disp_icon].x = Icon7.Left + 150;
            IconElements[disp_icon].y = Icon7.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 7;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon8(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //多角形の頂点の位置を設定
            Point[] points = {
                new Point(0, 0),
                new Point(100, 0),
                new Point(100, 50),
                new Point(0, 50)};
            byte[] types =
                {(byte) System.Drawing.Drawing2D.PathPointType.Line,
                    (byte) System.Drawing.Drawing2D.PathPointType.Line,
                    (byte) System.Drawing.Drawing2D.PathPointType.Line,
                    (byte) System.Drawing.Drawing2D.PathPointType.Line};
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.getchar;
            IconElements[disp_icon].x = Icon8.Left + 150;
            IconElements[disp_icon].y = Icon8.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 8;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon9(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.sleep;
            IconElements[disp_icon].x = Icon9.Left + 150;
            IconElements[disp_icon].y = Icon9.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 9;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon10(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.substitute;
            IconElements[disp_icon].x = Icon10.Left + 150;
            IconElements[disp_icon].y = Icon10.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].SizeMode = PictureBoxSizeMode.StretchImage;
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 10;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon11(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.endup_image;
            IconElements[disp_icon].x = Icon11.Left + 150;
            IconElements[disp_icon].y = Icon11.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].SizeMode = PictureBoxSizeMode.StretchImage;
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 11;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon,j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void CreateIcon12(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            //コントロールのサイズを適当に変更
            Icons[disp_icon].SetBounds(0, 0, 101, 101);
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
            //コントロールの形を変更
            Icons[disp_icon].Region = new Region(path);
            this.Icons[disp_icon].BringToFront();
            this.Icons[disp_icon].Visible = true;
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = disp_icon;
            this.Icons[disp_icon].Image = global::WindowsFormsApp1.Properties.Resources.rand;
            IconElements[disp_icon].x = Icon12.Left + 150;
            IconElements[disp_icon].y = Icon12.Top + pnlContainer.Top;
            this.Icons[disp_icon].Location = new Point((int)IconElements[disp_icon].x, (int)IconElements[disp_icon].y);
            this.Icons[disp_icon].SizeMode = PictureBoxSizeMode.StretchImage;
            this.Icons[disp_icon].Size = new Size(100, 50);
            IconElements[disp_icon].type = 12;
            IconElements[disp_icon].enable = true;
            for (int j = 0; j < 10; j++) Lines[disp_icon, j] = 0;
            IconElements[disp_icon].LineCount = 0;
            if (disp_icon < this.Icons.Length - 1) disp_icon++;
            if (disp_icon > NowMax) NowMax++;
            this.ResumeLayout(false);
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language = 0; //Languageが0の時、英語で表示する
            英語ToolStripMenuItem.Checked = true;
            日本語ToolStripMenuItem.Checked = false;
            表示ToolStripMenuItem.Text = "View";
            説明jkToolStripMenuItem.Text = "Icons Description";
            実行ToolStripMenuItem.Text = "Run";
            保存ToolStripMenuItem.Text = "File";
            編集ToolStripMenuItem.Text = "Edit";
            設定ToolStripMenuItem.Text = "Setting";
            コードの出力ToolStripMenuItem.Text = "Code Generation";
            プログラムの実行ToolStripMenuItem.Text = "Programs Run";
            ハイライトモードToolStripMenuItem.Text = "Highlights Mode";
            名前を付けて保存ToolStripMenuItem.Text = "Save As";
            ファイルを開くToolStripMenuItem.Text = "Open";
            上書き保存ToolStripMenuItem.Text = "Save";
            アイコンをリセットToolStripMenuItem.Text = "Reset";
            ラインをリセットToolStripMenuItem.Text = "Reset All Wires";
            アイコンの整列ToolStripMenuItem.Text = "Fall in Icons";
            変数の管理ToolStripMenuItem.Text = "Controll Variable";
            言語設定ToolStripMenuItem.Text = "Language";
            日本語ToolStripMenuItem.Text = "Japanese";
            英語ToolStripMenuItem.Text = "English";
            ユーザーレベルToolStripMenuItem.Text = "User level";
            wire_delete.Text = "Delete Wire";
        }

        private void 日本語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language = 1; //Languageが1の時、日本語で表示
            英語ToolStripMenuItem.Checked = false;
            日本語ToolStripMenuItem.Checked = true;
            表示ToolStripMenuItem.Text = "表示";
            説明jkToolStripMenuItem.Text = "各アイコンの説明";
            実行ToolStripMenuItem.Text = "実行";
            保存ToolStripMenuItem.Text = "ファイル";
            編集ToolStripMenuItem.Text = "編集";
            設定ToolStripMenuItem.Text = "設定";
            コードの出力ToolStripMenuItem.Text = "コードの出力";
            プログラムの実行ToolStripMenuItem.Text = "プログラムの出力";
            ハイライトモードToolStripMenuItem.Text = "ハイライトモード";
            名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            上書き保存ToolStripMenuItem.Text = "上書き保存";
            ファイルを開くToolStripMenuItem.Text = "ファイルを開く";
            アイコンをリセットToolStripMenuItem.Text = "リセット";
            ラインをリセットToolStripMenuItem.Text = "ラインをリセット";
            アイコンの整列ToolStripMenuItem.Text = "アイコンの整列";
            変数の管理ToolStripMenuItem.Text = "変数の管理";
            言語設定ToolStripMenuItem.Text = "言語設定";
            日本語ToolStripMenuItem.Text = "日本語";
            英語ToolStripMenuItem.Text = "英語";
            ユーザーレベルToolStripMenuItem.Text = "ユーザーレベル";
            wire_delete.Text = "ワイヤー消去モード";
        }
        private void Icon_MouseMove(object sender, MouseEventArgs e)
        {
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            if (Controlling>=0&&IconElements[Controlling].movable == true)
            {
                IconElements[Controlling].x -= IconElements[Controlling].xx - mousex;
                IconElements[Controlling].y -= IconElements[Controlling].yy - mousey;
                IconElements[Controlling].xx = mousex;
                IconElements[Controlling].yy = mousey;

                this.Icons[Controlling].Location = new Point((int)IconElements[Controlling].x, (int)IconElements[Controlling].y);

                Draw();
            }
            double distance = 9999999999;
            int n = -1;
            int p = 0;
            if (Controlling >= 0)
            {
                for (int i = 0; i < Max; i++)
                {
                    if(i != Controlling)
                    {
                        if (IconElements[i].connectto == Controlling || IconElements[i].connectto2 == Controlling) p = 1;
                        if (IconElements[i].enable == true && IconElements[i].connectto == -1 && IconElements[i].type != 2)
                        {
                            double d = System.Math.Pow((Icons[i].Left - Icons[Controlling].Left), 2) + System.Math.Pow(Icons[i].Bottom - Icons[Controlling].Top, 2);
                            if (distance > d)
                            {
                                distance = d;
                                n = i;
                            }
                        }
                    }
                }
                double s = System.Math.Pow((StartIcon.Left - Icons[Controlling].Left), 2) + System.Math.Pow(StartIcon.Bottom - Icons[Controlling].Top, 2);
                if (distance > s && StartElements.connectto == -1 && (StartIcon.Left < Icons[Controlling].Right && StartIcon.Right > Icons[Controlling].Left) && (StartIcon.Bottom < Icons[Controlling].Top && StartIcon.Bottom > Icons[Controlling].Top - 80))
                {
                    cfrom = -2;
                    cto = Controlling;
                }
                else if ((n != -1) && (p == 0) && (Icons[n].Left < Icons[Controlling].Right && Icons[n].Right > Icons[Controlling].Left) && (Icons[n].Bottom < Icons[Controlling].Top && Icons[n].Bottom > Icons[Controlling].Top - 80))
                {
                    cfrom = n;
                    cto = Controlling;
                }
                else
                {
                    cfrom = -1;
                    cto = -1;
                }
            }
            this.MainMenuStrip.BringToFront();
        }


        private void StartDown(object sender, MouseEventArgs e)
        {
            Controlling = -1;
            switch (e.Button)               //startIcon用
            {
                case MouseButtons.Left:
                    m = 1;
                    //Console.Write(m);
                    break;

                case MouseButtons.Right:
                    Clickt++;
                    if (Clickt == 1)
                    {
                        if (delete == 0)
                        {
                            m = (m + 1) % 2;
                            //Console.Write(m);
                            if (m == 0)
                            {
                                FirstClicked = Controlling;
                                this.StartIcon.Image = global::WindowsFormsApp1.Properties.Resources.start_select;
                            }
                            if (m == 1)
                            {
                                if (FirstClicked == -1)
                                {
                                    this.StartIcon.Image = global::WindowsFormsApp1.Properties.Resources.start;
                                }
                                else
                                {
                                    if (IconElements[FirstClicked].type == 1) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.printf;
                                }
                            }
                        }
                        else
                        {
                            StartElements.connectto = -1;
                            Draw();
                        }
                    }
                    break;
            }
        }

        private void StartUp(object sender, MouseEventArgs e)
        {
            Clickt =0;
        }

        private void コードの出力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Code.Show();
            Code.SendDataLanguage = Language.ToString();
            Code.SendData = Generate();

        }
        private void ハイライトモードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Code2.Show();
            Code2.SendDataLanguage = Language.ToString();
            Code2.SendData = Generate();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = Language;
            Properties.Settings.Default.Save();
            e.Cancel = false;
        }

        private void EndDown(object sender, MouseEventArgs e)
        {
            this.EndIcon.BringToFront();
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            Controlling = -2;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    EndElements.movable = true;
                    EndElements.x = EndIcon.Left;
                    EndElements.y = EndIcon.Top;
                    EndElements.xx = mousex;
                    EndElements.yy = mousey;
                    this.EndIcon.BringToFront();
                    this.MainMenuStrip.BringToFront();
                    m = 1;
                    //Console.Write(m);
                    break;

                case MouseButtons.Right:
                    Clickt++;
                    if (Clickt == 1)
                    {
                        m = (m + 1) % 2;
                        //Console.Write(m);
                        if (m == 0)
                        {
                        }
                        if (m == 1)
                        {
                            if (FirstClicked == -1)
                            {
                                StartElements.connectto = -2;
                                this.StartIcon.Image = global::WindowsFormsApp1.Properties.Resources.start;
                            }
                            else
                            {
                                IconElements[FirstClicked].connectto = Controlling;
                                if (IconElements[FirstClicked].type == 1) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.printf;
                                if (IconElements[FirstClicked].type == 2) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._if;
                                if (IconElements[FirstClicked].type == 3) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.if_end;
                                if (IconElements[FirstClicked].type == 4) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.scanf;
                                if (IconElements[FirstClicked].type == 5) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._for;
                                if (IconElements[FirstClicked].type == 6) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.for_end;
                                if (IconElements[FirstClicked].type == 7) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources._while;
                                if (IconElements[FirstClicked].type == 8) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.getchar;
                                if (IconElements[FirstClicked].type == 9) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.sleep;
                                if (IconElements[FirstClicked].type == 10) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.substitute;
                                if (IconElements[FirstClicked].type == 11) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.endup_image;
                                if (IconElements[FirstClicked].type == 12) this.Icons[FirstClicked].Image = global::WindowsFormsApp1.Properties.Resources.rand;
                            }
                            Draw();
                        }
                    }
                    break;
            }
        }

        private void EndUp(object sender, MouseEventArgs e)
        {
            EndElements.movable = false;
            Clickt = 0;
        }

        private void EndMove(object sender, MouseEventArgs e)
        {
            Point cp = this.PointToClient(System.Windows.Forms.Cursor.Position);
            mousex = cp.X;
            mousey = cp.Y;
            if (EndElements.movable == true)
            {
                EndElements.x -= EndElements.xx - mousex;
                EndElements.y -= EndElements.yy - mousey;
                EndElements.xx = mousex;
                EndElements.yy = mousey;

                this.EndIcon.Location = new Point((int)EndElements.x, (int)EndElements.y);

                Draw();
            }
            this.MainMenuStrip.BringToFront();
        }


        private void アイコンをリセットToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Language)
            {
                case 0:
                    DialogResult result2 = MessageBox.Show("Do you want to reset all settings?",
                     "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result2 == DialogResult.Yes)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            StartElements.connectto = -1;
                            IconElements[j].enable = false;
                            IconElements[j].connectto = -1;
                            IconElements[j].connectto2 = -1;
                            this.Icons[j].Visible = false;
                            IconElements[j].a = 0;          //汎用変数(if用)
                            IconElements[j].text1 = "";
                            IconElements[j].text2 = "";
                            IconElements[j].text3 = "";
                            IconElements[j].number1 = 0;
                            IconElements[j].number2 = 0;
                            IconElements[j].mode = 0;       //文字列を表示するか変数の中身を表示するか
                            IconElements[j].Check1 = false;    //フォーム内でチェックがあるか否か
                            Draw();
                        }
                        var_count = 0;
                        for (int i = 0; i < 128; i++)
                        {
                            var_class[i] = "";
                            var_contents[i] = "";
                            var_init[i] = false;
                            var_value[i] = "";
                        }
                        上書き保存ToolStripMenuItem.Enabled = false;
                    }
                    else if (result2 == DialogResult.No)
                    {
                    }
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("現在の状況をすべてリセットしますか",
                     "警告",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            StartElements.connectto = -1;
                            IconElements[j].enable = false;
                            IconElements[j].connectto = -1;
                            IconElements[j].connectto2 = -1;
                            this.Icons[j].Visible = false;
                            IconElements[j].a = 0;          //汎用変数(if用)
                            IconElements[j].text1 = "";
                            IconElements[j].text2 = "";
                            IconElements[j].text3 = "";
                            IconElements[j].number1 = 0;
                            IconElements[j].number2 = 0;
                            IconElements[j].mode = 0;       //文字列を表示するか変数の中身を表示するか
                            IconElements[j].Check1 = false;    //フォーム内でチェックがあるか否か
                            Draw();
                        }
                        var_count = 0;
                        for (int i = 0; i < 128; i++)
                        {
                            var_class[i] = "";
                            var_contents[i] = "";
                            var_init[i] = false;
                            var_value[i] = "";
                        }
                        上書き保存ToolStripMenuItem.Enabled = false;
                    }
                    else if (result == DialogResult.No)
                    {
                    }
                    break;
            }
        }

        private void ラインをリセットToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Language)
            {
                case 0:
                    DialogResult result = MessageBox.Show("Do you want to reset all wires?",
                     "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            StartElements.connectto = -1;
                            IconElements[j].connectto = -1;
                            IconElements[j].connectto2 = -1;
                            Draw();
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                    }
                    break;
                case 1:
                    DialogResult result2 = MessageBox.Show("ワイヤをすべてリセットしますか",
                     "警告",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result2 == DialogResult.Yes)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            StartElements.connectto = -1;
                            IconElements[j].connectto = -1;
                            IconElements[j].connectto2 = -1;
                            Draw();
                        }
                    }
                    else if (result2 == DialogResult.No)
                    {
                    }
                    break;
            }
        }
        private void Scroll(object sender, MouseEventArgs e)
        {
            int Wheel = (e.Delta / 120);
            for (int i = 0; i < NowMax; i++)
            {
                IconElements[i].y += Wheel * 20;
                Icons[i].Top += Wheel * 20;
            }
            StartElements.y += Wheel * 20;
            StartIcon.Top += Wheel * 20;
            EndIcon.Top += Wheel * 20;
            this.MainMenuStrip.BringToFront();
            Draw();
        }
        private void アイコンの整列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int Viewing = StartElements.connectto;
                int old = -1;
                int[] ifstack = new int[128];
                int[] ifstack2 = new int[128];
                int[] ifstack3 = new int[128];
                int[] now = new int[128];
                for (int i = 0; i < 128; i++) ifstack[i] = -1;
                for (int i = 0; i < 128; i++) ifstack3[i] = -1;
                while (Viewing != -2)
                {
                    //Console.Write("0:" + ifstack[0] + " 1;" + ifstack[1] + Environment.NewLine);
                    if (Viewing == -1)
                    {
                        throw new FileNotFoundException();
                    }
                    else if (IconElements[Viewing].type == 2)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        ifstack[i] = Viewing;
                        now[i] = 0;
                        if (old == -1)
                        {
                            Icons[Viewing].Top = StartIcon.Bottom + 10;
                            IconElements[Viewing].y = Icons[Viewing].Top;
                            Icons[Viewing].Left = StartIcon.Left;
                            IconElements[Viewing].x = Icons[Viewing].Left;
                        }
                        else if (IconElements[old].type != 2)
                        {
                            Icons[Viewing].Top = Icons[old].Bottom + 10;
                            IconElements[Viewing].y = Icons[Viewing].Top;
                            Icons[Viewing].Left = Icons[old].Left;
                            IconElements[Viewing].x = Icons[Viewing].Left;
                        }
                        else if (IconElements[old].type == 2)
                        {
                            if (IconElements[old].connectto == Viewing)
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                                Icons[Viewing].Left = Icons[old].Left;
                                IconElements[Viewing].x = Icons[Viewing].Left;
                            }
                            else
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                                Icons[Viewing].Left = Icons[old].Left + ifstack3[i-1] * 150;
                                IconElements[Viewing].x = Icons[Viewing].Left;
                            }
                        }
                        old = Viewing;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 3)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        i--;
                        if (now[i] == 0)
                        {
                            if(IconElements[ifstack[i]].connectto2!=-1)
                            {
                                for (int j = 0;j <=i; j++)
                                {
                                    if (ifstack3[j + 1] >= ifstack3[j] - 1 || ifstack3[j + 1] == -1)
                                    {
                                        if (ifstack3[j] != -1) ifstack3[j]++;
                                        else ifstack3[j] = 1;

                                        Console.Write("j:" + 0 + " ifstack:" + ifstack3[0] + Environment.NewLine);
                                        Console.Write("j:" + 1 + " ifstack:" + ifstack3[1] + Environment.NewLine);
                                        Console.Write("j:" + 2 + " ifstack:" + ifstack3[2] + Environment.NewLine);
                                        Console.Write(Environment.NewLine);
                                    }
                                }
                                ifstack2[i] = old;
                                old = ifstack[i];
                                Viewing = IconElements[ifstack[i]].connectto2;
                            }
                            else
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                                Icons[Viewing].Left = Icons[ifstack[i]].Left;
                                IconElements[Viewing].x = Icons[Viewing].Left;
                                now[i] = 0;
                                old = Viewing;
                                Viewing = IconElements[Viewing].connectto;
                                ifstack[i] = -1;
                            }
                            now[i] = 1;
                        }
                        else
                        {
                            if (Icons[ifstack2[i]].Bottom > Icons[old].Bottom)
                            {
                                Icons[Viewing].Top = Icons[ifstack2[i]].Bottom + 10;
                                Icons[Viewing].Top += Icons[ifstack2[i]].Bottom - Icons[old].Bottom;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                            }
                            else
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                            }
                            Icons[Viewing].Left = Icons[ifstack[i]].Left;
                            IconElements[Viewing].x = Icons[Viewing].Left;
                            ifstack3[i] = -1;
                            now[i] = 0;
                            old = Viewing;
                            Viewing = IconElements[Viewing].connectto;
                            ifstack[i] = -1;
                        }
                    }
                    else
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        i--;
                        if (old == -1)
                        {
                            Icons[Viewing].Top = StartIcon.Bottom + 10;
                            IconElements[Viewing].y = Icons[Viewing].Top;
                            Icons[Viewing].Left = StartIcon.Left;
                            IconElements[Viewing].x = Icons[Viewing].Left;
                        }
                        else if (IconElements[old].type != 2)
                        {
                            Icons[Viewing].Top = Icons[old].Bottom + 10;
                            IconElements[Viewing].y = Icons[Viewing].Top;
                            Icons[Viewing].Left = Icons[old].Left;
                            IconElements[Viewing].x = Icons[Viewing].Left;

                        }
                        else if(IconElements[old].type == 2)
                        {
                            if(IconElements[old].connectto==Viewing)
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                                Icons[Viewing].Left = Icons[old].Left;
                                IconElements[Viewing].x = Icons[Viewing].Left;
                            }
                            else
                            {
                                Icons[Viewing].Top = Icons[old].Bottom + 10;
                                IconElements[Viewing].y = Icons[Viewing].Top;
                                Icons[Viewing].Left = Icons[old].Left + ifstack3[i]*150;
                                IconElements[Viewing].x = Icons[Viewing].Left;
                            }
                        }
                        old = Viewing;
                        Viewing = IconElements[Viewing].connectto;
                    }
                }
                EndIcon.Top = Icons[old].Bottom + 10;
                EndIcon.Left = Icons[old].Left;
            }
            catch
            {
            }
            Draw();
        }

        private void 変数の管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm3.Show();
            fm3.SendDataLanguage = Language.ToString();
        }
        public string Receiveid
        {
            set
            {
                id = int.Parse(value);
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataText1
        {
            set
            {
                try
                {
                    IconElements[id].text1 = value;
                }
                catch
                {
                    MessageBox.Show("値の変更に失敗しました",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataText2
        {
            set
            {
                try
                {
                    IconElements[id].text2 = value;
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataText3
        {
            set
            {
                try
                {
                    IconElements[id].text3 = value;
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataInt1
        {
            set
            {
                try
                {
                    IconElements[id].number1 = int.Parse(value);
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataInt2
        {
            set
            {
                try
                {
                    IconElements[id].number2 = int.Parse(value);
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveDataCheck1
        {
            set
            {
                try
                {
                    IconElements[id].Check1 = bool.Parse(value);
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }
        public string ReceiveMode
        {
            set
            {
                try
                {
                    modereceive = value;
                    IconElements[id].mode = int.Parse(modereceive);
                    id = -1;
                }
                catch
                {

                }
            }
            get
            {
                return "";
            }
        }

        private void printfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pfs.Show();
        }

        private void ifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ifs.Show();
        }

        private void scanfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scs.Show();
        }

        private void forToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fors.Show();
        }

        private void whileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whs.Show();
        }

        private void switchcaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sws.Show();
        }

        private void プログラムの実行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            error = 0;
            string code = Generate();
            try
            {
                //SaveFileDialog.FileName = Path.GetFileName(this.FileName);
                File.WriteAllText("a.c", code, Encoding.GetEncoding("Shift_JIS"));
                // ファイル名を保持する
                this.FileName = "a.c";


                //Processオブジェクトを作成

                System.Diagnostics.Process p = new System.Diagnostics.Process();

                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                //ウィンドウを表示しないようにする
                p.StartInfo.CreateNoWindow = false;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                p.StartInfo.Arguments = @"/c compile.bat";

                //起動
                p.Start();

                //出力を読み取る
                string results = p.StandardOutput.ReadToEnd();

                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                p.WaitForExit();
                p.Close();

                //出力された結果を表示
                Console.WriteLine(Directory.GetCurrentDirectory());
                Console.WriteLine(results);
                if (error == 0)
                {
                    System.Diagnostics.Process p2 =
                            System.Diagnostics.Process.Start("a.exe");
                }
            }
            catch
            {
                /*
                if (Language == 1)
                {
                    MessageBox.Show("コードの作成に失敗",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                if (Language == 0)
                {
                    MessageBox.Show("Fail To Generate Code",
                   "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                */
            }
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Level = 3;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.OP == 1) DebugMenu.Visible = true;
            PassMenu.Visible = true;
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Level = 2;
            Properties.Settings.Default.Save();
            PassMenu.Visible = false;
        }

        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Level = 1;
            Properties.Settings.Default.Save();
            PassMenu.Visible = false;
        }

        private void DebugMenu_Click(object sender, EventArgs e)
        {
            ps.Show();
        }
        private void DebugMenu_Click_1(object sender, EventArgs e)
        {
            db.Show();
        }
        private void getcharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gets.Show();
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sles.Show();
        }

        private void substitudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subs.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exits.Show();
        }
        private void randToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rands.Show();
        }
        public string ReceivePass
        {
            set
            {
                try
                {
                    switch (value)
                    {
                        case "password":
                            Properties.Settings.Default.OP = 1;
                            Properties.Settings.Default.Save();
                            DebugMenu.Visible = true;
                            break;
                    }
                }
                catch
                {
                }
            }
            get
            {
                return "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            delete = (delete + 1) % 2;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pnlContainer.Size = new Size(pictureBox1.Width, this.Height-100);
            pictureBox1.Size = new Size(pictureBox1.Width+10, this.Height);
            Trash.Location = new Point(this.Width - Trash.Width - 30, this.Height - Trash.Height - 30);     //ゴミ箱表示場所変更
            wire_delete.Location = new Point((Trash.Left + 20), (Trash.Top - 10));    //ワイヤー消去モード表示場所変更
        }

        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = Path.GetFileName(this.FileName);
            if (DialogResult.OK == SaveFileDialog.ShowDialog())
            {
                SaveFile(SaveFileDialog.FileName);
            }
        }
        private void SaveFile(string value)
        {
            for (int i = 0; i < Max; i++)
            {
                ary.enable[i] = IconElements[i].enable;
                ary.x[i] = IconElements[i].x;
                ary.y[i] = IconElements[i].y;
                ary.xx[i] = IconElements[i].xx;
                ary.yy[i] = IconElements[i].yy;
                ary.movable[i] = IconElements[i].movable;
                ary.connectto[i] = IconElements[i].connectto;
                ary.connectto2[i] = IconElements[i].connectto2;
                ary.type[i] = IconElements[i].type;
                ary.a[i] = IconElements[i].a;
                ary.text1[i] = IconElements[i].text1;
                ary.text2[i] = IconElements[i].text2;
                ary.text3[i] = IconElements[i].text3;
                ary.number1[i] = IconElements[i].number1;
                ary.mode[i] = IconElements[i].mode;
                ary.Check1[i] = IconElements[i].Check1;


            }
            for (int i = 0; i < 128; i++)
            {
                ary.var_class[i] = var_class[i];
                ary.var_contents[i] = var_contents[i];
                ary.var_init[i] = var_init[i];
                ary.var_value[i] = var_value[i];
            }
            ary.disp_Icon = disp_icon;
            ary.NowMax = NowMax;
            ary.var_count = var_count;

            ary.startenable = StartElements.enable;
            ary.startx = StartIcon.Left;
            ary.starty = StartIcon.Top;
            ary.startxx = StartElements.xx;
            ary.startyy = StartElements.yy;
            ary.startmovable = StartElements.movable;
            ary.startconnectto = StartElements.connectto;
            ary.startconnectto2 = StartElements.connectto2;
            ary.starttype = StartElements.type;
            ary.starta = StartElements.a;
            ary.starttext1 = StartElements.text1;
            ary.starttext2 = StartElements.text2;
            ary.starttext3 = StartElements.text3;
            ary.startnumber1 = StartElements.number1;
            ary.startmode = StartElements.mode;
            ary.startCheck1 = StartElements.Check1;

            ary.endenable = EndElements.enable;
            ary.endx = EndIcon.Left;
            ary.endy = EndIcon.Top;
            ary.endxx = EndElements.xx;
            ary.endyy = EndElements.yy;
            ary.endmovable = EndElements.movable;
            ary.endconnectto = EndElements.connectto;
            ary.endconnectto2 = EndElements.connectto2;
            ary.endtype = EndElements.type;
            ary.enda = EndElements.a;
            ary.endtext1 = EndElements.text1;
            ary.endtext2 = EndElements.text2;
            ary.endtext3 = EndElements.text3;
            ary.endnumber1 = EndElements.number1;
            ary.endmode = EndElements.mode;
            ary.endCheck1 = EndElements.Check1;
            //var ary = new test();
            XmlSerializer serializer1 = new XmlSerializer(typeof(test));
            StreamWriter sw = new StreamWriter(value, false, Encoding.GetEncoding("Shift_JIS"));
            serializer1.Serialize(sw, ary);
            sw.Close();
            this.FileName = value;

            上書き保存ToolStripMenuItem.Enabled = true;
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(this.FileName);
        }

        private void ファイルを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "";
            if (DialogResult.OK == OpenFileDialog.ShowDialog())
            {
                LoadFile(OpenFileDialog.FileName);
            }
        }
        private void LoadFile(string value)
        {
            test loadAry;
            XmlSerializer serializer2 = new XmlSerializer(typeof(test));
            StreamReader sr = new StreamReader(value, Encoding.GetEncoding("Shift_JIS"));
            loadAry = (test)serializer2.Deserialize(sr);
            sr.Close();
            this.FileName = value;
            for (int i = 0; i < Max; i++)
            {
                IconElements[i].enable = loadAry.enable[i];
                IconElements[i].x = loadAry.x[i];
                IconElements[i].y = loadAry.y[i];
                IconElements[i].xx = loadAry.xx[i];
                IconElements[i].yy = loadAry.yy[i];
                IconElements[i].movable = loadAry.movable[i];
                IconElements[i].connectto = loadAry.connectto[i];
                IconElements[i].connectto2 = loadAry.connectto2[i];
                IconElements[i].type = loadAry.type[i];
                IconElements[i].a = loadAry.a[i];
                IconElements[i].text1 = loadAry.text1[i];
                IconElements[i].text2 = loadAry.text2[i];
                IconElements[i].text3 = loadAry.text3[i];
                IconElements[i].number1 = loadAry.number1[i];
                IconElements[i].number2 = loadAry.number2[i];
                IconElements[i].mode = loadAry.mode[i];
                IconElements[i].Check1 = loadAry.Check1[i];
                if (IconElements[i].enable == true) Icons[i].Visible = true;
                else Icons[i].Visible = false;
                Icons[i].SetBounds(0, 0, 101, 101);
                if (IconElements[i].type == 1)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.printf;
                }
                if (IconElements[i].type == 2)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(diamond, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources._if;
                }
                if (IconElements[i].type == 3)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(diamond, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.if_end;
                }
                if (IconElements[i].type == 4)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.scanf;
                }
                if (IconElements[i].type == 5)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(trapezoid, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources._for;
                }
                if (IconElements[i].type == 6)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(r_trapezoid, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.for_end;
                }
                if (IconElements[i].type == 7)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(trapezoid, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources._while;
                }
                if (IconElements[i].type == 8)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.getchar;
                }
                if (IconElements[i].type == 9)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.sleep;
                }
                if (IconElements[i].type == 10)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.substitute;
                }
                if (IconElements[i].type == 11)
                {
                    //GraphicsPathの作成
                    System.Drawing.Drawing2D.GraphicsPath path =
                        new System.Drawing.Drawing2D.GraphicsPath(rectangle, types4);
                    //コントロールの形を変更
                    Icons[i].Region = new Region(path);
                    this.Icons[i].Image = global::WindowsFormsApp1.Properties.Resources.endup_image;
                }
                Icons[i].Left = (int)loadAry.x[i];
                Icons[i].Top = (int)loadAry.y[i];
                this.Icons[i].Size = new Size(100, 50);
                this.Icons[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Icons[i].BringToFront();
            }
            for (int i = 0; i < 128; i++)
            {
                var_class[i] = loadAry.var_class[i];
                var_contents[i] = loadAry.var_contents[i];
                var_init[i] = loadAry.var_init[i];
                var_value[i] = loadAry.var_value[i];
            }
            disp_icon = loadAry.disp_Icon;
            NowMax = loadAry.NowMax;
            var_count = loadAry.var_count;

            StartElements.enable = loadAry.startenable;
            StartElements.x = loadAry.startx;
            StartElements.y = loadAry.starty;
            StartElements.xx = loadAry.startxx;
            StartElements.yy = loadAry.startyy;
            StartElements.movable = loadAry.startmovable;
            StartElements.connectto = loadAry.startconnectto;
            StartElements.connectto2 = loadAry.startconnectto2;
            StartElements.type = loadAry.starttype;
            StartElements.a = loadAry.starta;
            StartElements.text1 = loadAry.starttext1;
            StartElements.text2 = loadAry.starttext2;
            StartElements.text3 = loadAry.starttext3;
            StartElements.number1 = loadAry.startnumber1;
            StartElements.number2 = loadAry.startnumber2;
            StartElements.mode = loadAry.startmode;
            StartElements.Check1 = loadAry.startCheck1;

            StartIcon.Top = (int)StartElements.y;
            StartIcon.Left = (int)StartElements.x;

            EndElements.enable = loadAry.endenable;
            EndElements.x = loadAry.endx;
            EndElements.y = loadAry.endy;
            EndElements.xx = loadAry.endxx;
            EndElements.yy = loadAry.endyy;
            EndElements.movable = loadAry.endmovable;
            EndElements.connectto = loadAry.endconnectto;
            EndElements.connectto2 = loadAry.endconnectto2;
            EndElements.type = loadAry.endtype;
            EndElements.a = loadAry.enda;
            EndElements.text1 = loadAry.endtext1;
            EndElements.text2 = loadAry.endtext2;
            EndElements.text3 = loadAry.endtext3;
            EndElements.number1 = loadAry.endnumber1;
            EndElements.number2 = loadAry.endnumber2;
            EndElements.mode = loadAry.endmode;
            EndElements.Check1 = loadAry.endCheck1;

            EndIcon.Top = (int)EndElements.y;
            EndIcon.Left = (int)EndElements.x;

            Draw();

            上書き保存ToolStripMenuItem.Enabled = true;
        }

        void Draw(){
            // Graphicsオブジェクトの作成
            Graphics gr = panel1.CreateGraphics();
            //背景全体に白のグラフィックを表示してClearのようにする。
            gr.Clear(Color.White);
            // Graphicsを解放する
            gr.Dispose();
            // Graphicsオブジェクトの作成
            Graphics g = panel1.CreateGraphics();
            // penを作成
            Pen blackPen = new Pen(Color.Black, 4);
            Pen bluePen = new Pen(Color.Blue, 4);
            for (int i = 0; i < NowMax; i++)
            {
                if (IconElements[i].connectto == -2)
                {
                    // lineの始点と終点を設定
                    Point Start_point1 = 
                        new Point(this.Icons[i].Left + this.Icons[i].Width / 2, this.Icons[i].Top + this.Icons[i].Height / 2);
                    Point End_point1 = 
                        new Point(this.Icons[i].Left + this.Icons[i].Width / 2, 
                        (this.EndIcon.Top + this.EndIcon.Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    Start_point1 =
                        new Point(this.Icons[i].Left + this.Icons[i].Width / 2,
                        (this.EndIcon.Top + this.EndIcon.Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    End_point1 =
                        new Point(this.EndIcon.Left + this.EndIcon.Width / 2, 
                        (this.EndIcon.Top + this.EndIcon.Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    g.DrawLine(blackPen, Start_point1, End_point1);
              
                    Start_point1 = 
                        new Point(this.EndIcon.Left + this.EndIcon.Width / 2, 
                        (this.EndIcon.Top + this.EndIcon.Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    End_point1 =
                        new Point(this.EndIcon.Left + this.EndIcon.Width / 2, this.EndIcon.Top + this.EndIcon.Height / 2);
                    g.DrawLine(blackPen, Start_point1, End_point1);

                }

                else if (IconElements[i].connectto != -1)
                {

                    // lineの始点と終点を設定
                    Point Start_point1 = new Point(this.Icons[i].Left + this.Icons[i].Width / 2, this.Icons[i].Top + this.Icons[i].Height / 2);
                    Point End_point1 = new Point(this.Icons[i].Left + this.Icons[i].Width / 2, (this.Icons[IconElements[i].connectto].Top + this.Icons[IconElements[i].connectto].Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.Icons[i].Left + this.Icons[i].Width / 2, (this.Icons[IconElements[i].connectto].Top + this.Icons[IconElements[i].connectto].Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    End_point1 = new Point(this.Icons[IconElements[i].connectto].Left + this.Icons[IconElements[i].connectto].Width / 2, (this.Icons[IconElements[i].connectto].Top + this.Icons[IconElements[i].connectto].Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.Icons[IconElements[i].connectto].Left + this.Icons[IconElements[i].connectto].Width / 2, (this.Icons[IconElements[i].connectto].Top + this.Icons[i].Height / 2 + this.Icons[i].Top + this.Icons[i].Height / 2) / 2);
                    End_point1 = new Point(this.Icons[IconElements[i].connectto].Left + this.Icons[IconElements[i].connectto].Width / 2, this.Icons[IconElements[i].connectto].Top + this.Icons[IconElements[i].connectto].Height / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);
                }
                if (IconElements[i].connectto2 != -1)
                {
                    // lineの始点と終点を設定
                    Point Start_point1 = new Point(this.Icons[i].Left + this.Icons[i].Width / 2, this.Icons[i].Top + this.Icons[i].Height / 2);
                    Point End_point1 = new Point(this.Icons[IconElements[i].connectto2].Left + this.Icons[IconElements[i].connectto2].Width / 2, this.Icons[i].Top + this.Icons[i].Height / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.Icons[IconElements[i].connectto2].Left + this.Icons[IconElements[i].connectto2].Width / 2, this.Icons[i].Top + this.Icons[i].Height / 2);
                    End_point1 = new Point(this.Icons[IconElements[i].connectto2].Left + this.Icons[IconElements[i].connectto2].Width / 2, this.Icons[IconElements[i].connectto2].Top + this.Icons[IconElements[i].connectto2].Height / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);
                }
            }
            if (StartElements.connectto != -1)
            {
                if (StartElements.connectto == -2)
                {
                    // lineの始点と終点を設定
                    Point Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, this.StartIcon.Top + this.StartIcon.Height / 2);
                    Point End_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.EndIcon.Top + this.EndIcon.Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.EndIcon.Top + this.EndIcon.Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                    End_point1 = new Point(this.EndIcon.Left + this.EndIcon.Width / 2, (this.EndIcon.Top + this.EndIcon.Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.EndIcon.Left + this.EndIcon.Width / 2, (this.EndIcon.Top + this.EndIcon.Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                    End_point1 = new Point(this.EndIcon.Left + this.EndIcon.Width / 2, this.EndIcon.Top + this.EndIcon.Height / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);
                }
                else
                {
                    // lineの始点と終点を設定
                    Point Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, this.StartIcon.Top + this.StartIcon.Height / 2);
                    Point End_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.Icons[StartElements.connectto].Top + this.Icons[StartElements.connectto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.Icons[StartElements.connectto].Top + this.Icons[StartElements.connectto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                    End_point1 = new Point(this.Icons[StartElements.connectto].Left + this.Icons[StartElements.connectto].Width / 2, (this.Icons[StartElements.connectto].Top + this.Icons[StartElements.connectto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);

                    // lineの始点と終点を設定
                    Start_point1 = new Point(this.Icons[StartElements.connectto].Left + this.Icons[StartElements.connectto].Width / 2, (this.Icons[StartElements.connectto].Top + this.Icons[StartElements.connectto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                    End_point1 = new Point(this.Icons[StartElements.connectto].Left + this.Icons[StartElements.connectto].Width / 2, this.Icons[StartElements.connectto].Top + this.Icons[StartElements.connectto].Height / 2);

                    // lineを描画
                    g.DrawLine(blackPen, Start_point1, End_point1);
                }
            }
            if (cfrom > -1)
            {
                // lineの始点と終点を設定
                Point Start_point1 = new Point(this.Icons[cfrom].Left + this.Icons[cfrom].Width / 2, this.Icons[cfrom].Top + this.Icons[cfrom].Height / 2);
                Point End_point1 = new Point(this.Icons[cfrom].Left + this.Icons[cfrom].Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.Icons[cfrom].Top + this.Icons[cfrom].Height / 2) / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);

                // lineの始点と終点を設定
                Start_point1 = new Point(this.Icons[cfrom].Left + this.Icons[cfrom].Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.Icons[cfrom].Top + this.Icons[cfrom].Height / 2) / 2);
                End_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.Icons[cfrom].Top + this.Icons[cfrom].Height / 2) / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);

                // lineの始点と終点を設定
                Start_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, (this.Icons[cto].Top + this.Icons[cfrom].Height / 2 + this.Icons[cfrom].Top + this.Icons[cfrom].Height / 2) / 2);
                End_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, this.Icons[cto].Top + this.Icons[cto].Height / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);
            }
            if(cfrom == -2)
            {
                // lineの始点と終点を設定
                Point Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, this.StartIcon.Top + this.StartIcon.Height / 2);
                Point End_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);

                // lineの始点と終点を設定
                Start_point1 = new Point(this.StartIcon.Left + this.StartIcon.Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                End_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, (this.Icons[cto].Top + this.Icons[cto].Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);

                // lineの始点と終点を設定
                Start_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, (this.Icons[cto].Top + this.StartIcon.Height / 2 + this.StartIcon.Top + this.StartIcon.Height / 2) / 2);
                End_point1 = new Point(this.Icons[cto].Left + this.Icons[cto].Width / 2, this.Icons[cto].Top + this.Icons[cto].Height / 2);

                // lineを描画
                g.DrawLine(bluePen, Start_point1, End_point1);
            }

            // lineを描画
            blackPen.Dispose();

            // Graphicsを解放する
            g.Dispose();
        }
        string Generate()
        {
            int LineCount = 0;
            string code = "#include <stdio.h>" + Environment.NewLine;
            LineCount++;
            int Win = 0;
            int Lib = 0;
            int Time = 0;
            int random = 0;
            for (int i = 0; i < NowMax; i++)
            {
                if (IconElements[i].enable == true && IconElements[i].type == 9 && Win == 0)
                {
                    code += "#include <Windows.h>" + Environment.NewLine;
                    LineCount++;
                    Win = 1;
                }
                if (IconElements[i].enable == true && IconElements[i].type == 12 && Lib==0 && Time == 0)
                {
                    code += "#include <stdlib.h>" + Environment.NewLine;
                    code += "#include <time.h>" + Environment.NewLine;
                    LineCount++;
                    Lib = 1;
                    Time = 0;
                    random = 1;
                }
            }
            code += Environment.NewLine + "int main(void)" + Environment.NewLine + "{" + Environment.NewLine;
            LineCount += 3;
            try
            {
                int Viewing = StartElements.connectto;
                int[] ifstack = new int[128];
                int[] now = new int[128];
                for (int i = 0; i < var_count; i++)
                {
                    if (var_class[i] == "char[256]") code += "    " + "char" + " " + var_contents[i] + "[256]";
                    else code += "    " + var_class[i] + " " + var_contents[i];
                    if (var_init[i] == true && var_class[i] == "char[256]") code += " = \"" + var_value[i] + "\";";
                    else if(var_init[i] == true)code += " = " + var_value[i] + ";";
                    else code += ";";
                    code += Environment.NewLine;
                    LineCount++;
                }
                for (int i = 0; i < 128; i++) ifstack[i] = -1;
                int indent = 1;
                if(random==1)
                {
                    code += "    srand((unsigned)time(NULL));" + Environment.NewLine;
                }
                while (Viewing != -2)
                {
                    //Console.Write("0:" + ifstack[0] + " 1;" + ifstack[1] + Environment.NewLine);
                    if (Viewing == -1)
                    {
                        throw new FileNotFoundException();
                    }
                    else if (IconElements[Viewing].type == 1)//printf
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "printf(\"";
                        if (IconElements[Viewing].mode == 1)
                        {
                            code += IconElements[Viewing].text1;
                            if (IconElements[Viewing].Check1 == true) code += "\\n";
                            code += "\");" + Environment.NewLine;
                            Lines[Viewing, 0] = LineCount;
                            IconElements[Viewing].LineCount = 1;
                            LineCount++;
                        }
                        else
                        {
                            int i;
                            int none = 0;
                            for (i = 0; (i < Max) && (var_contents[i] != IconElements[Viewing].text1); i++) { }
                            if (var_class[i] == "int")
                            {
                                code += "%d";
                            }
                            else if (var_class[i] == "float")
                            {
                                code += "%f";

                            }
                            else if (var_class[i] == "char")
                            {
                                code += "%c";

                            }
                            else if (var_class[i] == "char[256]")
                            {
                                code += "%s";

                            }
                            else if (var_class[i] == "bool")
                            {
                                code += "%d";

                            }
                            else
                            {
                                none = 1;
                            }
                            if (IconElements[Viewing].Check1 == true) code += "\\n";
                            if (none == 1) code += "\"" + IconElements[Viewing].text1 + ");" + Environment.NewLine;
                            else code += "\"," + IconElements[Viewing].text1 + ");" + Environment.NewLine;
                            Lines[Viewing, 0] = LineCount;
                            IconElements[Viewing].LineCount = 1;
                            LineCount++;
                        }
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 2)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        ifstack[i] = Viewing;
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "if(";
                        code += IconElements[Viewing].text1;
                        if (IconElements[Viewing].number1 == 1) code += ">";
                        if (IconElements[Viewing].number1 == 2) code += "==";
                        if (IconElements[Viewing].number1 == 4) code += "<";
                        if (IconElements[Viewing].number1 == 3) code += ">=";
                        if (IconElements[Viewing].number1 == 6) code += "<=";
                        code += IconElements[Viewing].text2;
                        code += ")" + Environment.NewLine;
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "{" + Environment.NewLine;
                        indent++;
                        now[i] = 0;
                        Lines[Viewing, 0] = LineCount;
                        Lines[Viewing, 1] = LineCount + 1;
                        IconElements[Viewing].LineCount = 2;
                        LineCount += 2;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 3)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        i--;
                        if (now[i] == 0)
                        {
                            if (IconElements[ifstack[i]].connectto2 != -1)
                            {
                                Lines[ifstack[i], 2] = LineCount;
                                Lines[ifstack[i], 3] = LineCount + 1;
                                Lines[ifstack[i], 4] = LineCount + 2;
                                IconElements[ifstack[i]].LineCount = 5;
                                //IconElements[Viewing].LineCount = 2;
                                indent--;
                                for (int j = 0; j < indent; j++) code += "    ";
                                code += "}" + Environment.NewLine;
                                for (int j = 0; j < indent; j++) code += "    ";
                                code += "else" + Environment.NewLine;
                                for (int j = 0; j < indent; j++) code += "    ";
                                code += "{" + Environment.NewLine;
                                Viewing = IconElements[ifstack[i]].connectto2;
                                indent++;
                                now[i] = 1;
                                LineCount += 3;
                            }
                            else
                            {
                                Lines[ifstack[i], 2] = LineCount;
                                IconElements[ifstack[i]].LineCount = 3;
                                IconElements[Viewing].LineCount = 3;
                                indent--;
                                for (int j = 0; j < indent; j++) code += "    ";
                                code += "}" + Environment.NewLine;
                                now[i] = 0;
                                Viewing = IconElements[Viewing].connectto;
                                ifstack[i] = -1;
                                LineCount ++;
                            }
                        }
                        else
                        {
                            Lines[ifstack[i], 5] = LineCount;
                            IconElements[ifstack[i]].LineCount = 6;
                            Console.Write(" | " + Lines[ifstack[i], 2] + Lines[ifstack[i], 3] + Lines[ifstack[i], 4]);
                            //Lines[ifstack[i], 3] = LineCount;
                            //IconElements[Viewing].LineCount = 3;
                            indent--;
                            for (int j = 0; j < indent; j++) code += "    ";
                            code += "}" + Environment.NewLine;
                            now[i] = 0;
                            Viewing = IconElements[Viewing].connectto;
                            ifstack[i] = -1;
                            LineCount++;
                        }
                    }
                    else if (IconElements[Viewing].type == 4)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "scanf(\"";
                        int i;
                        for (i = 0; (i < Max) && (var_contents[i] != IconElements[Viewing].text1); i++) { }
                        if (var_class[i] == "int")
                        {
                            code += "%d";
                        }
                        else if (var_class[i] == "float")
                        {
                            code += "%f";

                        }
                        else if (var_class[i] == "char")
                        {
                            code += "%c";

                        }
                        else if (var_class[i] == "char[256]")
                        {
                            code += "%s";

                        }
                        else if (var_class[i] == "bool")
                        {
                            code += "%d";

                        }
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        code += "\",&" + IconElements[Viewing].text1 + ");" + Environment.NewLine;
                        Viewing = IconElements[Viewing].connectto;
                        LineCount++;
                    }
                    else if (IconElements[Viewing].type == 5)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "for(int i = 0; i<" + IconElements[Viewing].number1 + "; i++)" + Environment.NewLine;
                        for (int j = 0; j < indent; j++) code += "    ";
                        code +="{" + Environment.NewLine;
                        indent++;
                        Lines[Viewing, 0] = LineCount;
                        Lines[Viewing, 1] = LineCount + 1;
                        IconElements[Viewing].LineCount = 2;
                        Viewing = IconElements[Viewing].connectto;
                        LineCount+=2;
                    }
                    else if (IconElements[Viewing].type == 6)
                    {
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount ++;
                        indent--;
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "}" + Environment.NewLine;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 7)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "while(";
                        code += IconElements[Viewing].text1;
                        if (IconElements[Viewing].number1 == 1) code += ">";
                        if (IconElements[Viewing].number1 == 2) code += "==";
                        if (IconElements[Viewing].number1 == 4) code += "<";
                        if (IconElements[Viewing].number1 == 3) code += ">=";
                        if (IconElements[Viewing].number1 == 6) code += "<=";
                        code += IconElements[Viewing].text2;
                        code += ")" + Environment.NewLine;
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "{" + Environment.NewLine;
                        indent++;
                        Lines[Viewing, 0] = LineCount;
                        Lines[Viewing, 1] = LineCount + 1;
                        IconElements[Viewing].LineCount = 2;
                        LineCount += 2;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 8)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        if (IconElements[Viewing].text1 == "") code += "getchar();" + Environment.NewLine;
                        else code +=  IconElements[Viewing].text1 + " = getchar();" + Environment.NewLine;
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount ++;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 9)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "Sleep(" + IconElements[Viewing].number1 + ");" + Environment.NewLine;
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount++;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 10)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += IconElements[Viewing].text1 + "=" + IconElements[Viewing].text2 + ";" + Environment.NewLine;
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount++;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 11)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += "while(getchar()!='" + IconElements[Viewing].text1 + "'){}" + Environment.NewLine;
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount++;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else if (IconElements[Viewing].type == 12)
                    {
                        for (int j = 0; j < indent; j++) code += "    ";
                        code += IconElements[Viewing].text1 + "= rand()%" + (IconElements[Viewing].number2 + 1) + " +" + IconElements[Viewing].number1 + ";" + Environment.NewLine;
                        Lines[Viewing, 0] = LineCount;
                        IconElements[Viewing].LineCount = 1;
                        LineCount++;
                        Viewing = IconElements[Viewing].connectto;
                    }
                    else
                    {
                        Viewing = IconElements[Viewing].connectto;
                    }
                }
                code += "}";
            }
            catch
            {
                error = 1;
                if (Language == 1)
                {
                    MessageBox.Show("コードの作成に失敗",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                if (Language == 0)
                {
                    MessageBox.Show("Fail To Generate Code",
                   "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            return code;
        }
        
    }
}