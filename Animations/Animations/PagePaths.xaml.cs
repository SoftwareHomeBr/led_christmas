using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Animations
{
    

    public partial class PagePaths : Page
    {
        public FalaSerial falaSerial;
        TextBlock m_lbstatus;
        Timer m_vaiFalando;
        Timer m_timer;
        Label m_txb;
        Action m_veraxTxb;
        // Create a Storyboard to contain and apply the animation.
        Storyboard pathAnimationStoryboard = new Storyboard();
        Random m_rr = new Random(DateTime.Now.Millisecond);
        Canvas mainPanel;
        Brush[] m_cores = new Brush[] { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Purple, Brushes.LightBlue, Brushes.Pink, Brushes.LightGreen, Brushes.Magenta, Brushes.Yellow, Brushes.Cyan };
        string[] m_coresTexto = new string[] { "G", "E", "F", "H", "4", "5", "6", "3","8", "A", "C", "8", "7", "G", "1", "2", "D" }; 
        int contaCor = 0;
        Image m_veraxImage = new Image();
        Action m_actionVerax;
        int contaFelizNatal = 0;
        Point[] __m_psFELIZNATAL = { new Point(110, 208), new Point(108, 191), new Point(109, 176), new Point(108, 159), new Point(108, 142), new Point(110, 130), new Point(109, 112), new Point(109, 99), new Point(108, 89), new Point(109, 76), new Point(123, 76), new Point(135, 75), new Point(149, 75), new Point(160, 74), new Point(173, 74), new Point(120, 141), new Point(134, 141), new Point(146, 141), new Point(160, 141), new Point(170, 141), new Point(291, 83), new Point(273, 80), new Point(259, 79), new Point(246, 79), new Point(233, 79), new Point(223, 80), new Point(221, 89), new Point(220, 101), new Point(220, 114), new Point(218, 126), new Point(220, 141), new Point(220, 151), new Point(220, 168), new Point(219, 182), new Point(219, 190), new Point(220, 199), new Point(235, 200), new Point(247, 200), new Point(253, 200), new Point(270, 203), new Point(285, 202), new Point(232, 138), new Point(246, 138), new Point(258, 135), new Point(271, 137), new Point(282, 137), new Point(344, 78), new Point(345, 87), new Point(344, 97), new Point(341, 117), new Point(342, 109), new Point(342, 128), new Point(342, 139), new Point(342, 149), new Point(341, 159), new Point(343, 169), new Point(341, 178), new Point(344, 189), new Point(347, 198), new Point(358, 198), new Point(370, 201), new Point(383, 201), new Point(394, 202), new Point(403, 200), new Point(445, 75), new Point(448, 86), new Point(446, 97), new Point(446, 108), new Point(443, 122), new Point(439, 147), new Point(441, 131), new Point(442, 162), new Point(441, 176), new Point(444, 188), new Point(444, 199), new Point(503, 83), new Point(518, 79), new Point(534, 77), new Point(546, 79), new Point(565, 79), new Point(568, 91), new Point(555, 112), new Point(531, 138), new Point(545, 126), new Point(524, 153), new Point(518, 170), new Point(504, 184), new Point(499, 197), new Point(519, 201), new Point(538, 201), new Point(551, 200), new Point(567, 200), new Point(53, 422), new Point(50, 408), new Point(51, 394), new Point(50, 374), new Point(50, 356), new Point(50, 339), new Point(51, 322), new Point(48, 299), new Point(70, 302), new Point(80, 321), new Point(85, 335), new Point(93, 344), new Point(99, 355), new Point(105, 365), new Point(113, 384), new Point(122, 395), new Point(135, 412), new Point(151, 414), new Point(151, 399), new Point(152, 382), new Point(151, 367), new Point(151, 352), new Point(153, 338), new Point(153, 325), new Point(148, 306), new Point(203, 418), new Point(213, 395), new Point(219, 373), new Point(225, 362), new Point(222, 345), new Point(229, 338), new Point(231, 321), new Point(242, 310), new Point(252, 301), new Point(270, 308), new Point(272, 328), new Point(281, 344), new Point(284, 357), new Point(286, 365), new Point(292, 376), new Point(294, 384), new Point(302, 397), new Point(312, 410), new Point(272, 391), new Point(257, 390), new Point(239, 391), new Point(388, 422), new Point(387, 411), new Point(386, 390), new Point(384, 366), new Point(385, 341), new Point(390, 322), new Point(390, 308), new Point(392, 297), new Point(345, 304), new Point(360, 306), new Point(372, 296), new Point(401, 300), new Point(416, 300), new Point(428, 302), new Point(437, 300), new Point(474, 423), new Point(471, 410), new Point(474, 399), new Point(477, 385), new Point(484, 366), new Point(488, 355), new Point(490, 343), new Point(497, 330), new Point(503, 318), new Point(514, 309), new Point(531, 303), new Point(542, 318), new Point(545, 332), new Point(545, 341), new Point(549, 349), new Point(551, 364), new Point(558, 378), new Point(567, 400), new Point(574, 414), new Point(543, 383), new Point(537, 389), new Point(521, 391), new Point(502, 390), new Point(625, 297), new Point(625, 312), new Point(621, 331), new Point(623, 354), new Point(621, 377), new Point(622, 395), new Point(625, 411), new Point(631, 418), new Point(646, 418), new Point(660, 418), new Point(674, 419), new Point(688, 420) };
        Point[] m_psFELIZ2017 = { new Point(100,29), new Point(86,29), new Point(69,31), new Point(50,31), new Point(38,31), new Point(35,47), new Point(35,56), new Point(36,67), new Point(35,88), new Point(33,76), new Point(39,98), new Point(38,108), new Point(36,120), new Point(36,135), new Point(36,82), new Point(39,84), new Point(48,84), new Point(57,83), new Point(60,83), new Point(71,83), new Point(73,83), new Point(75,83), new Point(85,82), new Point(202,126), new Point(194,128), new Point(176,129), new Point(163,129), new Point(149,125), new Point(144,113), new Point(140,96), new Point(140,79), new Point(148,63), new Point(171,55), new Point(185,56), new Point(195,63), new Point(200,73), new Point(201,80), new Point(196,92), new Point(189,94), new Point(163,97), new Point(172,94), new Point(145,94), new Point(250,134), new Point(251,116), new Point(251,98), new Point(251,80), new Point(251,62), new Point(251,48), new Point(251,41), new Point(251,25), new Point(251,21), new Point(307,134), new Point(303,116), new Point(303,102), new Point(303,85), new Point(303,77), new Point(301,67), new Point(300,58), new Point(300,29), new Point(297,16), new Point(345,59), new Point(361,61), new Point(364,62), new Point(373,62), new Point(385,62), new Point(404,59), new Point(396,64), new Point(386,75), new Point(380,86), new Point(368,96), new Point(359,109), new Point(353,118), new Point(344,125), new Point(341,133), new Point(355,133), new Point(369,131), new Point(375,131), new Point(385,131), new Point(388,131), new Point(395,133), new Point(403,133), new Point(30,232), new Point(43,228), new Point(70,223), new Point(80,223), new Point(94,227), new Point(54,225), new Point(104,239), new Point(104,243), new Point(94,256), new Point(87,262), new Point(77,269), new Point(63,279), new Point(53,288), new Point(50,294), new Point(49,297), new Point(41,307), new Point(37,310), new Point(37,315), new Point(48,316), new Point(58,312), new Point(60,312), new Point(69,312), new Point(79,313), new Point(89,316), new Point(91,318), new Point(111,321), new Point(185,217), new Point(173,217), new Point(154,224), new Point(153,227), new Point(148,237), new Point(148,246), new Point(145,264), new Point(144,275), new Point(144,293), new Point(144,309), new Point(157,320), new Point(163,321), new Point(186,322), new Point(197,322), new Point(201,310), new Point(203,296), new Point(208,283), new Point(209,272), new Point(211,259), new Point(211,252), new Point(211,237), new Point(202,216), new Point(258,233), new Point(270,231), new Point(281,227), new Point(284,225), new Point(298,219), new Point(299,225), new Point(299,228), new Point(299,240), new Point(299,249), new Point(299,250), new Point(296,266), new Point(296,280), new Point(296,281), new Point(291,293), new Point(290,300), new Point(290,307), new Point(259,317), new Point(280,316), new Point(293,317), new Point(306,318), new Point(324,316), new Point(266,318), new Point(387,321), new Point(389,315), new Point(391,307), new Point(394,298), new Point(396,292), new Point(403,279), new Point(405,273), new Point(408,267), new Point(410,265), new Point(419,252), new Point(424,244), new Point(428,236), new Point(429,233), new Point(429,231), new Point(429,228), new Point(426,223), new Point(419,223), new Point(407,223), new Point(404,222), new Point(390,222), new Point(382,222), new Point(374,223), new Point(367,224), new Point(365,224), new Point(360,226)};
    Point[] m_coordsArvore = { new Point(396, 629), new Point(416, 629), new Point(430, 628), new Point(448, 628), new Point(449, 610), new Point(452, 595), new Point(450, 579), new Point(441, 567), new Point(428, 567), new Point(406, 565), new Point(385, 565), new Point(360, 560), new Point(340, 559), new Point(325, 554), new Point(303, 550), new Point(283, 542), new Point(265, 537), new Point(251, 531), new Point(238, 523), new Point(222, 519), new Point(253, 517), new Point(268, 517), new Point(287, 515), new Point(302, 515), new Point(321, 511), new Point(338, 507), new Point(350, 504), new Point(366, 498), new Point(373, 490), new Point(352, 485), new Point(333, 481), new Point(318, 475), new Point(302, 470), new Point(284, 464), new Point(271, 458), new Point(254, 446), new Point(242, 431), new Point(260, 431), new Point(276, 431), new Point(293, 431), new Point(312, 429), new Point(329, 427), new Point(346, 424), new Point(366, 416), new Point(389, 407), new Point(376, 398), new Point(356, 395), new Point(342, 392), new Point(324, 385), new Point(306, 375), new Point(290, 366), new Point(274, 350), new Point(302, 347), new Point(322, 346), new Point(339, 346), new Point(363, 336), new Point(380, 331), new Point(399, 329), new Point(417, 318), new Point(428, 310), new Point(411, 306), new Point(398, 303), new Point(384, 300), new Point(384, 300), new Point(370, 298), new Point(353, 295), new Point(340, 294), new Point(324, 291), new Point(341, 281), new Point(360, 272), new Point(378, 263), new Point(393, 257), new Point(407, 246), new Point(422, 237), new Point(431, 223), new Point(443, 211), new Point(453, 193), new Point(466, 175), new Point(470, 156), new Point(475, 141), new Point(480, 129), new Point(465, 131), new Point(450, 140), new Point(435, 146), new Point(421, 151), new Point(440, 130), new Point(447, 115), new Point(455, 105), new Point(441, 90), new Point(429, 76), new Point(410, 67), new Point(421, 66), new Point(441, 69), new Point(459, 69), new Point(468, 49), new Point(477, 30), new Point(484, 18), new Point(490, 35), new Point(497, 50), new Point(501, 58), new Point(515, 61), new Point(531, 61), new Point(548, 57), new Point(568, 57), new Point(554, 67), new Point(541, 76), new Point(525, 89), new Point(512, 103), new Point(523, 112), new Point(533, 125), new Point(538, 132), new Point(549, 146), new Point(561, 155), new Point(533, 141), new Point(517, 136), new Point(500, 131), new Point(492, 129), new Point(492, 144), new Point(496, 155), new Point(500, 168), new Point(509, 177), new Point(512, 190), new Point(523, 203), new Point(529, 213), new Point(541, 223), new Point(555, 239), new Point(568, 249), new Point(583, 259), new Point(600, 266), new Point(611, 273), new Point(624, 276), new Point(640, 285), new Point(653, 287), new Point(623, 295), new Point(604, 296), new Point(587, 299), new Point(570, 299), new Point(553, 307), new Point(537, 307), new Point(551, 317), new Point(567, 326), new Point(580, 334), new Point(601, 339), new Point(617, 344), new Point(632, 346), new Point(649, 348), new Point(669, 351), new Point(682, 349), new Point(699, 352), new Point(685, 361), new Point(670, 371), new Point(657, 378), new Point(641, 383), new Point(627, 388), new Point(607, 394), new Point(590, 395), new Point(575, 398), new Point(559, 398), new Point(568, 408), new Point(581, 412), new Point(598, 418), new Point(615, 423), new Point(634, 426), new Point(649, 427), new Point(666, 429), new Point(682, 429), new Point(701, 429), new Point(716, 429), new Point(735, 426), new Point(723, 442), new Point(711, 450), new Point(696, 456), new Point(685, 461), new Point(670, 464), new Point(659, 471), new Point(644, 473), new Point(628, 476), new Point(613, 478), new Point(603, 481), new Point(583, 485), new Point(595, 493), new Point(600, 501), new Point(618, 510), new Point(641, 514), new Point(660, 520), new Point(682, 521), new Point(700, 522), new Point(719, 522), new Point(736, 519), new Point(750, 515), new Point(720, 533), new Point(706, 536), new Point(685, 542), new Point(666, 549), new Point(641, 555), new Point(623, 559), new Point(599, 564), new Point(582, 565), new Point(564, 569), new Point(544, 569), new Point(526, 570), new Point(510, 570), new Point(493, 570), new Point(483, 570), new Point(482, 586), new Point(480, 596), new Point(484, 610), new Point(482, 625), new Point(498, 624), new Point(510, 624), new Point(524, 624), new Point(541, 624) };
        Point[] m_coordsArvoreOLD = new Point[]
        { new Point(235,342), new Point(235,329), new Point(234,314),                new Point(204,312), new Point(179,308), new Point(147,299),                new Point(110,284), new Point(132,286), new Point(163,284),                new Point(199,271), new Point(175,264), new Point(149,255),                new Point(124,240), new Point(155,239), new Point(181,233),                new Point(204,223), new Point(174,216), new Point(155,204),                new Point(140,191), new Point(168,193), new Point(186,188),                new Point(204,180), new Point(221,173), new Point(198,166),                new Point(181,161), new Point(166,156), new Point(195,147),                new Point(212,135), new Point(225,122), new Point(239,104),                new Point(247,87), new Point(250,70), new Point(235,73),                new Point(221,78), new Point(235,56), new Point(223,42),                new Point(211,36), new Point(241,42), new Point(246,25),                new Point(250,13), new Point(257,32), new Point(259,40),                new Point(276,37), new Point(290,36), new Point(275,46),                new Point(271,57), new Point(275,65), new Point(284,80),                new Point(262,75), new Point(260,88), new Point(264,102),                new Point(271,114), new Point(278,125), new Point(292,135),                new Point(306,146), new Point(320,152), new Point(338,157),                new Point(311,166), new Point(292,169), new Point(277,172),                new Point(294,178), new Point(305,186), new Point(318,188),                new Point(331,192), new Point(344,193), new Point(358,194),                new Point(343,206), new Point(327,215), new Point(313,220),                new Point(297,221), new Point(310,232), new Point(328,232),                new Point(346,236), new Point(357,236), new Point(374,240),                new Point(360,253), new Point(345,261), new Point(330,266),                new Point(312,266), new Point(303,274), new Point(317,281),                new Point(334,285), new Point(352,289), new Point(365,287),                new Point(387,287), new Point(372,297), new Point(349,304),                new Point(331,309), new Point(313,310), new Point(296,316),                new Point(272,315), new Point(257,315), new Point(251,316),                new Point(250,326), new Point(250,338)};
        Point[] m_ESPIRAL = { new Point(118, 95), new Point(427, 41), new Point(870, 31), new Point(1348, 44), new Point(1754, 77), new Point(1842, 222), new Point(1858, 565), new Point(1787, 843), new Point(1519, 914), new Point(1219, 922), new Point(915, 924), new Point(624, 911), new Point(377, 919), new Point(200, 890), new Point(130, 714), new Point(156, 498), new Point(271, 392), new Point(504, 336), new Point(849, 327), new Point(1063, 348), new Point(1128, 481), new Point(1080, 581), new Point(917, 599), new Point(835, 542), new Point(823, 414), new Point(959, 371), new Point(999, 471) };
        List<Point> m_ESPIRAL_REVERSA;

        public PagePaths()
        {
            falaSerial = new FalaSerial(this.Dispatcher);
            m_ESPIRAL_REVERSA = new List<Point>();
            for (int i = m_ESPIRAL.Length - 1; i >= 0; i--)
            {
                m_ESPIRAL_REVERSA.Add(m_ESPIRAL[i]);
            }

            //Adjust FELIZNATAL offset
            for (int ix = 0; ix < m_psFELIZ2017.Length; ix++)
            {
                m_psFELIZ2017[ix].Offset(1000, 500);
            }


            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());


            // Create a Canvas to contain ellipsePath
            // and add it to the page.
            mainPanel = new Canvas();
            mainPanel.Width = 1920;
            mainPanel.Height = 1080;
            mainPanel.Margin = new Thickness(0);
            mainPanel.Background = Brushes.LightGray;
            this.Content = mainPanel;
            for (int ct = 0; ct < m_coordsArvore.Length; ct++)
            {
                EllipseGeometry animatedEllipseGeometry14 = new EllipseGeometry(m_coordsArvore[ct], 8, 8);
                this.RegisterName("AnimatedEllipseGeometry" + ct.ToString(), animatedEllipseGeometry14);
                addAPath("AnimatedEllipseGeometry" + ct.ToString(), animatedEllipseGeometry14, mainPanel, m_cores[ct % m_cores.Length], m_ESPIRAL, m_psFELIZ2017);
            }

            //System.Threading.Timer tm = new System.Threading.Timer(delegate (object data) { addAPath("AnimatedEllipseGeometry2", animatedEllipseGeometry2, mainPanel, Brushes.Red); }, null, 0, 2000);
            //pathAnimationStoryboard.Begin(this);

            mainPanel.Background = Brushes.Black.Clone();
            ColorAnimation animation;
            animation = new ColorAnimation();
            //** animation.From = Colors.DarkOrange;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 55);
            animation.From = mySolidColorBrush.Color;
            animation.To = Colors.Black;
            animation.Duration = new Duration(TimeSpan.FromSeconds(4));
            animation.AutoReverse = true;
            animation.RepeatBehavior = RepeatBehavior.Forever;
            mainPanel.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            pathAnimationStoryboard.Completed += PathAnimationStoryboard_Completed;
            pathAnimationStoryboard.Begin(this);

            mainPanel.MouseDown += MainPanel_MouseDown;
            mainPanel.KeyDown += MainPanel_KeyDown;
            this.Unloaded += PagePaths_Unloaded;

            AnimationPos();
            AnimationText();
            m_lbstatus = new TextBlock();
            m_lbstatus.Foreground = Brushes.Red;
            m_lbstatus.FontSize = 8;
            m_lbstatus.SetValue(Canvas.LeftProperty, 10.0);
            m_lbstatus.SetValue(Canvas.TopProperty, 10.0);

            m_lbstatus.Height = 80;
            m_lbstatus.Width = 1000;
            mainPanel.Children.Add(m_lbstatus);
            var tb = falaSerial.enumComms();
            System.Diagnostics.Debug.WriteLine(tb.Rows.Count.ToString());
            if (tb.Rows.Count > 0)
            {
                string porta = tb.Rows[0]["COMx"] as string;
                falaSerial.connect(porta);
                falaSerial.m_dadosRX = new Action<string>(recebeSerial);
                //falaSerial.write("X"); // coloca os LEDS em marquize 
                falaSerial.write("Z"); // coloca os LEDS em shutoff 
            }
            m_vaiFalando = new Timer(delegate (object o) { falador(); }, null, 100, 5000);
        }
        void falador()
        {
            falaSerial.write(m_coresTexto[contaCor % m_cores.Length]);
        }
        private void MainPanel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            falaSerial.write("Z");
            Action shutup = new Action(ByeBye);
            Timer tm = new Timer(delegate (object o) { Dispatcher.Invoke(shutup); }, null, 0, 1000);
        }

        private void PagePaths_Unloaded(object sender, RoutedEventArgs e)
        {
            falaSerial.write("Z");
        }

        private void MainPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            falaSerial.write("Z");
            Action shutup = new Action(ByeBye);
            Timer tm = new Timer(delegate (object o) { Dispatcher.Invoke(shutup); }, null, 0, 1000);

        }
        void ByeBye()
        {
            Application.Current.Shutdown(0);
        }
        void recebeSerial(string texto)
        {
            if (m_lbstatus != null)
                m_lbstatus.Text = texto;
            else
                System.Diagnostics.Debug.Write(texto);
        }

        void addAPath(string gName, EllipseGeometry animatedEllipseGeometry, Canvas mainPanel, Brush brush, Point[] m_psCAMINHO, Point[] m_psFigFinal)
        {
            // Create a Path element to display the geometry.
            Path ellipsePath = new Path();
            ellipsePath.Data = animatedEllipseGeometry;
            ellipsePath.Fill = brush;
            ellipsePath.Margin = new Thickness(15);
            ellipsePath.Name = gName;

            mainPanel.Children.Add(ellipsePath);
            int Ynum = m_rr.Next((int)mainPanel.Height);
            int Xnum = m_rr.Next((int)mainPanel.Width);
            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(animatedEllipseGeometry.Center.X, animatedEllipseGeometry.Center.Y);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            // Point[] m_ps = { new Point(123, 42), new Point(923, 43), new Point(1858, 52), new Point(1846, 960), new Point(948, 968), new Point(103, 956), new Point(124, 47) };
            for (int i = 0; i < m_psCAMINHO.Length; i++)
            {
                pBezierSegment.Points.Add(m_psCAMINHO[i]);
            }
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal++ % m_psFigFinal.Length]);
            //pBezierSegment.Points.Add(new Point(35 + Xnum, 0 + Ynum ));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);


            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(1 + m_rr.Next(18));
            centerPointAnimation.BeginTime = TimeSpan.FromSeconds(1 + m_rr.Next(3));
            centerPointAnimation.IsCumulative = true;
            // centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;
            // centerPointAnimation.AutoReverse = true;



            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, gName);
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            //*** pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);


            // Start the Storyboard when ellipsePath is loaded.
            ellipsePath.Loaded += delegate (object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                //pathAnimationStoryboard.Begin(this);
            };
           

            // pathAnimationStoryboard.Completed += PathAnimationStoryboard_Completed;
        }
        private void AnimationPos()
        {
            TextBlock txb = new TextBlock();
            txb.Text = "Boas Festas!!! - Verax";
            txb.FontSize = 80;
            txb.Foreground = Brushes.Lime;
            DropShadowEffect eff = new DropShadowEffect();
            eff.BlurRadius = 25; // Color="LightGreen" ShadowDepth="0" Direction="0" BlurRadius="25" 
            eff.Color = Colors.Yellow;
            eff.ShadowDepth = 0;
            eff.Direction = 0;
            txb.Effect = eff;
            txb.SetValue(Canvas.LeftProperty, 10.0);
            txb.SetValue(Canvas.TopProperty, 10.0);
            //mainPanel.Children.Add(txb);
            BitmapImage bt = new BitmapImage(new Uri(@"C:\Dados\TABERN\Propostas\HEMERA\Source\wpfOswSCR\wpfOswSCR\Images\Verax.png"));
            m_veraxImage.Source = bt;
            // im.Margin = new Thickness(-50, 500, 100, 100);
            mainPanel.Children.Add(m_veraxImage);

            m_veraxImage.SetValue(Canvas.LeftProperty, 1980.0);
            m_veraxImage.SetValue(Canvas.TopProperty, 100.0);

            //create an animation
            DoubleAnimation da = new DoubleAnimation();
            DoubleAnimation db = new DoubleAnimation();

            BounceEase BounceOrientation = new BounceEase();
            BounceOrientation.Bounces = 4;
            BounceOrientation.Bounciness = 2;

            ElasticEase elastic = new ElasticEase();
            elastic.Oscillations = 2;
            elastic.Springiness = 2;

            CircleEase circle = new CircleEase();
            circle.Ease(3);

            da.EasingFunction = circle; //elastic; // BounceOrientation;
            //set from animation to start position 
            //dont forget set canvas.left for grid if u dont u will get error
            da.From = mainPanel.Width;
            //set second position of grid
            da.To = 00;
            //set duration
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.AutoReverse = true;
            //run animation if u want stop ,start etc use story board
            //*** m_veraxImage.BeginAnimation(Canvas.LeftProperty, da);
            da.Completed += Da_Completed;

            db.EasingFunction = circle; //elastic; // BounceOrientation;
            //set from animation to start position 
            //dont forget set canvas.left for grid if u dont u will get error
            db.From = mainPanel.Width;
            //set second position of grid
            db.To = 00;
            //set duration
            db.Duration = new Duration(TimeSpan.FromSeconds(3));
            db.AutoReverse = true;
            //run animation if u want stop ,start etc use story board
            //*** m_veraxImage.BeginAnimation(Canvas.LeftProperty, da);

            m_actionVerax = new Action(delegate () { m_veraxImage.BeginAnimation(Canvas.LeftProperty, da);
                falaSerial.write(m_coresTexto[contaCor % m_cores.Length]);
                System.Diagnostics.Debug.WriteLine("m_veraxImage.BeginAnimation(Canvas.LeftProperty, da..."); });
           // txb.BeginAnimation(Canvas.LeftProperty, db);
        }
        private void AnimationText()
        {
            m_txb = new Label();
            m_txb.Content = "Boas Festas!!! - Verax";
            m_txb.FontSize = 120;
            m_txb.FontFamily = new FontFamily("Bauhaus 93");
            object oo = FontFamily.FamilyNames.Values; 
            SolidColorBrush textBrush = new SolidColorBrush(Colors.Blue);

            m_txb.Foreground = textBrush;
            DropShadowEffect eff = new DropShadowEffect();
            eff.BlurRadius = 25; // Color="LightGreen" ShadowDepth="0" Direction="0" BlurRadius="25" 
            eff.Color = Colors.Yellow;
            eff.ShadowDepth = 0;
            eff.Direction = 0;
            m_txb.Effect = eff;
            m_txb.SetValue(Canvas.LeftProperty, 10.0);
            m_txb.SetValue(Canvas.TopProperty, 10.0);
            mainPanel.Children.Add(m_txb);

            //create an animation
            DoubleAnimation da = new DoubleAnimation();
            DoubleAnimation db = new DoubleAnimation();

            BounceEase BounceOrientation = new BounceEase();
            BounceOrientation.Bounces = 4;
            BounceOrientation.Bounciness = 2;

            ElasticEase elastic = new ElasticEase();
            elastic.Oscillations = 2;
            elastic.Springiness = 2;
            Storyboard sb = new Storyboard();
            CircleEase circle = new CircleEase();
            circle.Ease(13);

           //** db.EasingFunction = elastic; //elastic; // BounceOrientation;
            //set from animation to start position 
            //dont forget set canvas.left for grid if u dont u will get error
            db.From = mainPanel.Width;
            //set second position of grid
            db.To = -1300;
            //set duration
            db.Duration = new Duration(TimeSpan.FromSeconds(18));
            db.AutoReverse = true;
            db.RepeatBehavior = RepeatBehavior.Forever;
            db.EasingFunction = circle; // BounceOrientation;
            da.From = 0.0;
            da.To = mainPanel.Height-500;
            da.Duration = new Duration(TimeSpan.FromSeconds(18));
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.EasingFunction = elastic;
            //run animation if u want stop ,start etc use story board
            //*** m_veraxImage.BeginAnimation(Canvas.LeftProperty, da);
            sb.Children.Add(da);
            sb.Children.Add(db);

            // Register the brush's name 
            
            this.RegisterName("Brush1", textBrush);

            LinearGradientBrushAnimation la = new LinearGradientBrushAnimation();

            var resources = App.Current.Resources.MergedDictionaries;// window1.Resources.MergedDictionaries;

            object o2 = (resources[1] as ResourceDictionary);//.Values.GetEnumerator().Current; // as LinearGradientBrush));
            object[] keys = (o2 as ResourceDictionary).Keys as object[];
            la.From = (o2 as ResourceDictionary)[keys[0]] as LinearGradientBrush;
            la.To = (o2 as ResourceDictionary)[keys[1]] as LinearGradientBrush;
            la.RepeatBehavior = RepeatBehavior.Forever;
            la.AutoReverse = true;
            la.Duration = TimeSpan.FromSeconds(1);
            m_txb.Foreground = (o2 as ResourceDictionary)[keys[0]] as LinearGradientBrush;
            m_txb.BeginAnimation(Label.ForegroundProperty, la);


            Storyboard.SetTarget(da, m_txb);
            Storyboard.SetTarget(db, m_txb);
            Storyboard.SetTargetProperty(db, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.TopProperty));
            //m_veraxTxb = new Action(delegate () {
            //    m_veraxImage.BeginAnimation(Canvas.LeftProperty, da);
            //    falaSerial.write(m_coresTexto[contaCor % m_cores.Length]);
            //    System.Diagnostics.Debug.WriteLine("m_veraxTxb.BeginAnimation(Canvas.LeftProperty, da...");
            //});
            System.Diagnostics.Debug.WriteLine("m_veraxTxb.BeginAnimation(Canvas.LeftProperty, db...");
            //m_txb.BeginAnimation(SolidColorBrush.ColorProperty, cc);
            sb.Begin();
            //m_txb.BeginAnimation(TextBlock.ForegroundProperty ,cc);
        }

        private void Da_Completed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Da_Completed(object sender...");
//            Action ac = new Action(reDispara);
//            Dispatcher.Invoke(ac);
            m_timer = new Timer(timeHandle, null, 500, 500);
        }

        int count = 0;

        private void PathAnimationStoryboard_Completed(object sender, EventArgs e)
        {
                //Timer tm = new Timer(timeHandle, null, 5000, 15000);
                Dispatcher.Invoke(m_actionVerax);
            count++;
            System.Diagnostics.Debug.WriteLine("PathAnimationStoryboard_Completed-" + count.ToString());
        }
//        Brush[] m_corBolas = new Brush[] { Brushes.Turquoise, Brushes.Yellow, Brushes.LightGreen, Brushes.Pink, Brushes.LightBlue, Brushes.Red, Brushes.Magenta };

        void mudaCores()
        {
            count++;
            contaCor = contaCor + m_rr.Next(m_cores.Length-1) ;
            Brush bb = m_cores[contaCor % m_cores.Length];
            falaSerial.write(m_coresTexto[contaCor  % m_cores.Length]);
            this.WindowTitle = count.ToString();
            int ics = 0;
            foreach (object p in mainPanel.Children)
            {
                if(contaCor % 8 == 0 )
                {
                    bb = m_cores[ics++ % m_cores.Length];
                }
                if (p is Path)
                    (p as Path).Fill = bb;
            }
            System.Diagnostics.Debug.Write("\nMudaCores " + contaCor.ToString() + " " + bb.ToString());

        }
        void circulaCores()
        {
            Brush bb = Brushes.Black;
            int ics = new Random(DateTime.Now.Millisecond).Next(255);
            foreach (object p in mainPanel.Children)
            {
                bb = m_cores[ics++ % m_cores.Length];
                if (p is Path)
                    (p as Path).Fill = bb;
            }
            System.Diagnostics.Debug.Write("\ncirculaCores " + contaCor.ToString() + " " + bb.ToString());
            this.InvalidateVisual();
        }
        int timerVezez = 0;

        void timeHandle(object data)
        {
            Action acc = new Action(circulaCores);
            Dispatcher.Invoke(acc);
            if(timerVezez++ < 15)
                return;
            Action ac = new Action(reDispara);
            Dispatcher.Invoke(ac);

            timerVezez = 0;
            m_timer.Dispose();
        }
        //--------------------------------------------------

        int switchCaminho = 0;
        private void reDispara()
        {
            switchCaminho++;
            mudaCores();
            pathAnimationStoryboard.ClearValue(Storyboard.ChildrenProperty);
            //pathAnimationStoryboard.Begin(this);
            foreach ( object s in mainPanel.Children)
            {

                if(s is Path)
                {
                    if (switchCaminho % 2 == 1)
                        addAPathJust((s as Path).Name, (s as Path).Data as EllipseGeometry, mainPanel, Brushes.White, m_ESPIRAL_REVERSA.ToArray(), m_coordsArvore);
                    else
                        addAPathJust((s as Path).Name, (s as Path).Data as EllipseGeometry, mainPanel, Brushes.White, m_ESPIRAL, m_psFELIZ2017);
                }
            }

            pathAnimationStoryboard.Begin(this);
           // Dispatcher.Invoke(m_actionVerax);
            System.Diagnostics.Debug.WriteLine("reDispara-" + switchCaminho.ToString());
        }
        void addAPathJust(string gName, EllipseGeometry animatedEllipseGeometry, Canvas mainPanel, Brush brush, Point[] m_psCAMINHO, Point[] m_psFigFinal)
        {

            int Ynum = m_rr.Next((int)mainPanel.Height);
            int Xnum = m_rr.Next((int)mainPanel.Width);
            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(animatedEllipseGeometry.Center.X, animatedEllipseGeometry.Center.Y);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            // Point[] m_ps = { new Point(123, 42), new Point(923, 43), new Point(1858, 52), new Point(1846, 960), new Point(948, 968), new Point(103, 956), new Point(124, 47) };
            for (int i = 0; i < m_psCAMINHO.Length; i++)
            {
                pBezierSegment.Points.Add(m_psCAMINHO[i]);
            }
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal % m_psFigFinal.Length]);
            pBezierSegment.Points.Add(m_psFigFinal[contaFelizNatal++ % m_psFigFinal.Length]);
            //pBezierSegment.Points.Add(new Point(35 + Xnum, 0 + Ynum ));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);


            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(1 + m_rr.Next(18));
            centerPointAnimation.BeginTime = TimeSpan.FromSeconds(1 + m_rr.Next(3));
            centerPointAnimation.IsCumulative = true;
            // centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;
            // centerPointAnimation.AutoReverse = true;



            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, gName);
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            //*** pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);
        }


    }

}
