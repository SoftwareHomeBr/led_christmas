using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Animations
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }

        TextBlock m_txb;
        Action m_veraxTxb;


        Storyboard myStoryboard;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Controllable Storyboard Example";
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(10);

            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";

            // Assign the rectangle a name by 
            // registering it with the page, so that
            // it can be targeted by storyboard
            // animations.
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;
            //myStackPanel.Children.Add(myRectangle);
            canvas1.Background = Brushes.Black;
            canvas1.Children.Add(myRectangle);
            //
            // Create an animation and a storyboard to animate the
            // rectangle.
            //
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Create the storyboard.
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
            //
            // Create some buttons to control the storyboard
            // and a panel to contain them.
            //
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;
            buttonPanel.Margin = new Thickness(1,30,0,0);
            Button beginButton = new Button();
            beginButton.Content = "Begin";
            beginButton.Click += new RoutedEventHandler(beginButton_Clicked);
            buttonPanel.Children.Add(beginButton);
            Button pauseButton = new Button();
            pauseButton.Content = "Pause";
            pauseButton.Click += new RoutedEventHandler(pauseButton_Clicked);
            buttonPanel.Children.Add(pauseButton);
            Button resumeButton = new Button();
            resumeButton.Content = "Resume";
            resumeButton.Click += new RoutedEventHandler(resumeButton_Clicked);
            buttonPanel.Children.Add(resumeButton);
            Button skipToFillButton = new Button();
            skipToFillButton.Content = "Skip to Fill";
            skipToFillButton.Click += new RoutedEventHandler(skipToFillButton_Clicked);
            buttonPanel.Children.Add(skipToFillButton);
            Button setSpeedRatioButton = new Button();
            setSpeedRatioButton.Content = "Triple Speed";
            setSpeedRatioButton.Click += new RoutedEventHandler(setSpeedRatioButton_Clicked);
            buttonPanel.Children.Add(setSpeedRatioButton);
            Button stopButton = new Button();
            stopButton.Content = "Stop";
            stopButton.Click += new RoutedEventHandler(stopButton_Clicked);
            buttonPanel.Children.Add(stopButton);
            myStackPanel.Children.Add(buttonPanel);
            //this.AddChild( myStackPanel);
            grid1.Children.Add(myStackPanel);

        }

        // Begins the storyboard.
        private void beginButton_Clicked(object sender, RoutedEventArgs args)
        {
            // Specifying "true" as the second Begin parameter
            // makes this storyboard controllable.
            myStoryboard.Begin(this, true);

        }

        // Pauses the storyboard.
        private void pauseButton_Clicked(object sender, RoutedEventArgs args)
        {
            myStoryboard.Pause(this);

        }

        // Resumes the storyboard.
        private void resumeButton_Clicked(object sender, RoutedEventArgs args)
        {
            myStoryboard.Resume(this);

        }

        // Advances the storyboard to its fill period.
        private void skipToFillButton_Clicked(object sender, RoutedEventArgs args)
        {
            myStoryboard.SkipToFill(this);

        }

        // Updates the storyboard's speed.
        private void setSpeedRatioButton_Clicked(object sender, RoutedEventArgs args)
        {
            // Makes the storyboard progress three times as fast as normal.
            myStoryboard.SetSpeedRatio(this, 3);

        }

        // Stops the storyboard.
        private void stopButton_Clicked(object sender, RoutedEventArgs args)
        {
            myStoryboard.Stop(this);

        }
        public void DoTransition()
        {
            double targetX = this.ActualWidth;

            myStoryboard.Stop();
            myStoryboard.Children.Clear();
            IEasingFunction easing = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
            DoubleAnimation translateXAnim = new DoubleAnimation()
            {
                To = targetX,
                Duration = TimeSpan.FromMilliseconds(250),
                EasingFunction = easing,
            };

            // 1. Refer to the element by Name
            Storyboard.SetTargetName(translateXAnim, "myRectangle");
            Storyboard.SetTargetProperty(translateXAnim, new PropertyPath(TranslateTransform.XProperty));
            myStoryboard.Children.Add(translateXAnim);
            // 2. Pass in the template context here
            myStoryboard.Begin(this, this.Template);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            // DoTransition();
            // Create_And_Run_Animation(sender, e);
            //colorAnim();
            AnimationPos();
        }
    private void Create_And_Run_Animation(object sender, EventArgs e)
        {
            // Create a red rectangle that will be the target
            // of the animation.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 50;
            myRectangle.Height = 50;
            Color myColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = myColor;
            myRectangle.Fill = myBrush;

            // Add the rectangle to the tree.
            canvas1.Children.Add(myRectangle);

            // Create a duration of 2 seconds.
            Duration duration = new Duration(TimeSpan.FromSeconds(2));

            // Create two DoubleAnimations and set their properties.
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation(0, 200, duration, FillBehavior.HoldEnd);
            DoubleAnimation myDoubleAnimation2 = new DoubleAnimation(0, 200, duration, FillBehavior.HoldEnd);

            myDoubleAnimation1.Duration = duration;
            myDoubleAnimation2.Duration = duration;
            myDoubleAnimation1.AutoReverse = true;
            myDoubleAnimation2.AutoReverse = true;
           // myDoubleAnimation1.RepeatBehavior = RepeatBehavior.Forever;
           // myDoubleAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard sb = new Storyboard();
            //sb.Duration = duration;

            sb.Children.Add(myDoubleAnimation1);
            sb.Children.Add(myDoubleAnimation2);

            Storyboard.SetTarget(myDoubleAnimation1, myRectangle);
            Storyboard.SetTarget(myDoubleAnimation2, myRectangle);

            // Set the attached properties of Canvas.Left and Canvas.Top
            // to be the target properties of the two respective DoubleAnimations.
            
            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath(Rectangle.HeightProperty));
            Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath(Rectangle.WidthProperty));

            //myDoubleAnimation1.To = 200;
            //myDoubleAnimation2.To = 200;

            // Make the Storyboard a resource.
            canvas1.Resources.Add("unique_id", sb);
            sb.Completed += Sb_Completed;
            // Begin the animation.
            sb.Begin();
            myStoryboard = sb;
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            Action aa = new Action(faz);
            Dispatcher.Invoke(aa);
        }
        int counter = 0;
        void faz()
        {
            Button2.Content = (++counter).ToString();
            myStoryboard.Begin();
        }
        void colorAnim()
        {
            this.canvas1.Background = Brushes.Black.Clone();
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = Colors.Orange;
            animation.To = Colors.Blue;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            animation.AutoReverse = true;
            this.canvas1.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }
        private void AnimationPos()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.Red;
            ellipse.Width = 10;
            ellipse.Height = 10;

            ellipse.SetValue(Canvas.LeftProperty, 100.0);
            ellipse.SetValue(Canvas.TopProperty, 100.0);

            canvas1.Children.Add(ellipse);
            //create an animation
            DoubleAnimation da = new DoubleAnimation();

            BounceEase BounceOrientation = new BounceEase();
            BounceOrientation.Bounces = 4;
            BounceOrientation.Bounciness = 2;

            da.EasingFunction = BounceOrientation;
            //set from animation to start position 
            //dont forget set canvas.left for grid if u dont u will get error
            da.From = canvas1.Margin.Left ;
            //set second position of grid
            da.To = -100;
            //set duration
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            //run animation if u want stop ,start etc use story board
            ellipse.BeginAnimation(Canvas.LeftProperty , da);

        }
        private void AnimationText()
        {
            
            Canvas mainPanel = canvas1;
            mainPanel.Background = Brushes.Black;
            m_txb = new TextBlock();
            m_txb.Text = "Boas Festas!!! - Verax---";
            m_txb.FontSize = 80;
            m_txb.Foreground = Brushes.Lime;
            DropShadowEffect eff = new DropShadowEffect();
            eff.BlurRadius = 25; // Color="LightGreen" ShadowDepth="0" Direction="0" BlurRadius="25" 
            eff.Color = Colors.Yellow;
            eff.ShadowDepth = 0;
            eff.Direction = 0;
            m_txb.Effect = eff;
            m_txb.SetValue(Canvas.LeftProperty, 10.0);
            m_txb.SetValue(Canvas.TopProperty, 10.0);
            mainPanel.Children.Add(m_txb);

           // m_txb.SetValue(Canvas.LeftProperty, 180.0);
           // m_txb.SetValue(Canvas.TopProperty, 1800.0);

            //create an animation
            
            DoubleAnimation db = new DoubleAnimation();



            BounceEase BounceOrientation = new BounceEase();
            BounceOrientation.Bounces = 4;
            BounceOrientation.Bounciness = 2;

            ElasticEase elastic = new ElasticEase();
            elastic.Oscillations = 2;
            elastic.Springiness = 2;

            CircleEase circle = new CircleEase();
            circle.Ease(3);

            //db.EasingFunction = circle; //elastic; // BounceOrientation;
            //set from animation to start position 
            //dont forget set canvas.left for grid if u dont u will get error
            db.From = 400;
            //set second position of grid
            db.To = 00;
            //set duration
            db.Duration = new Duration(TimeSpan.FromSeconds(3));
            db.AutoReverse = true;
            db.EasingFunction = BounceOrientation;
            DoubleAnimation dc = db.Clone();
            dc.EasingFunction = elastic;
            Storyboard sb = new Storyboard();
            sb.Children.Add(db);
            sb.Children.Add(dc);
            Storyboard.SetTarget(db, m_txb);
            Storyboard.SetTarget(dc, m_txb);
            Storyboard.SetTargetProperty(db, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTargetProperty(dc, new PropertyPath(Canvas.LeftProperty));
            //Storyboard.SetTargetProperty(db, Canvas.LeftProperty);
            GradientStopCollection gcolFrom = new GradientStopCollection();
            gcolFrom.Add(new GradientStop(Colors.Black, 10));
            GradientStopCollection gcolTo = new GradientStopCollection();
            gcolFrom.Add(new GradientStop(Colors.Red, 10));
            LinearGradientBrushAnimation linan = new LinearGradientBrushAnimation();
            linan.From = new LinearGradientBrush(gcolFrom, 90);
            linan.To = new LinearGradientBrush(gcolTo, 90);

            this.RegisterName("linan", linan);
            sb.Children.Add(linan);
            Storyboard.SetTargetName(linan, "linan");
            Storyboard.SetTargetProperty(linan, new PropertyPath(TextBlock.ForegroundProperty));
            System.Diagnostics.Debug.WriteLine("m_veraxTxb.BeginAnimation(Canvas.LeftProperty, db...");
            //m_txb.BeginAnimation(Canvas.LeftProperty, db);
            canvas1.Resources.Add("unique_id", sb);
            sb.Begin();
        }


        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new PointAnimationUsingPathExample();
            this.Content = new PagePaths();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            canvas1 = new Canvas();
            canvas1.Margin = new Thickness(5);
            grid1.Children.Add(canvas1);
            AnimationText();

            //Create_And_Run_Animation(null, null);
        }
    }
}
