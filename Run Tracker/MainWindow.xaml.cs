using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Run_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Run> items = new List<Run>();

        SqlConnection cs = new SqlConnection("Server=R6507002;Database=RunTracker;Trusted_Connection=True;");
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable ds = new DataTable("Runs");
        DataTable ds2 = new DataTable("Runs");

        User newUser = new User();

        public MainWindow()
        {
            InitializeComponent();
        }
 
        public void AddMileageRun_Click(object sender, RoutedEventArgs e)
        {
            MileageRun mileage = new MileageRun()
            {
                Distance = Convert.ToInt32(DistanceTB.Text),
                Pace = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text)),
                Time = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text)),
                Date = Date.Text,
                Type = "Mileage"
            };
            items.Add(mileage);

            da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES (@distance, @totaltime, @pace, @dateofrun, @typeofrun, @Runner)", cs);
            da.InsertCommand.Parameters.Add("@distance", SqlDbType.Int).Value = mileage.Distance;
            da.InsertCommand.Parameters.Add("@totaltime", SqlDbType.Time).Value = mileage.Time;
            da.InsertCommand.Parameters.Add("@pace", SqlDbType.Time).Value = mileage.Pace;
            da.InsertCommand.Parameters.Add("@dateofrun", SqlDbType.Date).Value = mileage.Date;
            da.InsertCommand.Parameters.Add("@typeofrun", SqlDbType.VarChar).Value = mileage.Type;
            da.InsertCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();
            UpdateRuns();
            MessageBox.Show("New Run added!");
        }

        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            Workout workout = new Workout()
            {
                NumOfIntervals = Convert.ToInt32(NumIntTB.Text),
                PaceOfIntervals = new TimeSpan(0, Convert.ToInt32(PaceIntMinTB.Text), Convert.ToInt32(PaceIntSecTB.Text)),
                DistOfIntervals = Convert.ToInt32(DistIntTB.Text),
                Time = TimeSpan.FromTicks(new TimeSpan(0, Convert.ToInt32(PaceIntMinTB.Text), Convert.ToInt32(PaceIntSecTB.Text)).Ticks * Convert.ToInt32(NumIntTB.Text) * Convert.ToInt32(DistIntTB.Text)),
                Date = Date.Text,
                Type = "Workout"
            };
            if (JogCB.IsChecked.Value)
            {
                workout.JogDist = Convert.ToInt32(JogDistTB.Text);
                workout.JogPace = new TimeSpan(0, Convert.ToInt32(JogPaceMinTB.Text), Convert.ToInt32(JogPaceSecTB.Text));
                workout.JogTime = new TimeSpan(Convert.ToInt32(JogTimeHourTB.Text), Convert.ToInt32(JogTimeMinTB.Text), Convert.ToInt32(JogTimeSecTB.Text));

                workout.CalculateWithRecovery();
            }
            else
            {
                workout.CalculateNoRecovery();
            }
            items.Add(workout);

            da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES (@distance, @totaltime, @pace, @dateofrun, @typeofrun, @Runner)", cs);
            da.InsertCommand.Parameters.Add("@distance", SqlDbType.Int).Value = workout.Distance;
            da.InsertCommand.Parameters.Add("@totaltime", SqlDbType.Time).Value = workout.Time;
            da.InsertCommand.Parameters.Add("@pace", SqlDbType.Time).Value = workout.Pace;
            da.InsertCommand.Parameters.Add("@dateofrun", SqlDbType.Date).Value = workout.Date;
            da.InsertCommand.Parameters.Add("@typeofrun", SqlDbType.VarChar).Value = workout.Type;
            da.InsertCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();
            UpdateRuns();
            MessageBox.Show("New Run added!");
        }

        private void WorkoutRB_Checked(object sender, RoutedEventArgs e)
        {
            DistanceTB.Visibility = Visibility.Hidden;
            DistanceText.Visibility = Visibility.Hidden;
            TimeText.Visibility = Visibility.Hidden;
            HourTB.Visibility = Visibility.Hidden;
            MinTB.Visibility = Visibility.Hidden;
            SecTB.Visibility = Visibility.Hidden;
            PaceText.Visibility = Visibility.Hidden;
            PaceTB.Visibility = Visibility.Hidden;
            PaceMinTB.Visibility = Visibility.Hidden;
            AddMileageRun.Visibility = Visibility.Hidden;

            NumIntText.Visibility = Visibility.Visible;
            NumIntTB.Visibility = Visibility.Visible;
            DistIntText.Visibility = Visibility.Visible;
            DistIntTB.Visibility = Visibility.Visible;
            PaceIntText.Visibility = Visibility.Visible;
            PaceIntMinTB.Visibility = Visibility.Visible;
            PaceIntSecTB.Visibility = Visibility.Visible;
            JogCB.Visibility = Visibility.Visible;
            Date.Visibility = Visibility.Visible;
            AddWorkout.Visibility = Visibility.Visible;
        }

        private void MileageRB_Checked(object sender, RoutedEventArgs e)
        {
            DistanceTB.Visibility = Visibility.Visible;
            DistanceText.Visibility = Visibility.Visible;
            TimeText.Visibility = Visibility.Visible;
            HourTB.Visibility = Visibility.Visible;
            MinTB.Visibility = Visibility.Visible;
            SecTB.Visibility = Visibility.Visible;
            PaceText.Visibility = Visibility.Visible;
            PaceTB.Visibility = Visibility.Visible;
            PaceMinTB.Visibility = Visibility.Visible;
            Date.Visibility = Visibility.Visible;
            AddMileageRun.Visibility = Visibility.Visible;

            NumIntText.Visibility = Visibility.Hidden;
            NumIntTB.Visibility = Visibility.Hidden;
            DistIntText.Visibility = Visibility.Hidden;
            DistIntTB.Visibility = Visibility.Hidden;
            PaceIntText.Visibility = Visibility.Hidden;
            PaceIntMinTB.Visibility = Visibility.Hidden;
            PaceIntSecTB.Visibility = Visibility.Hidden;
            JogCB.Visibility = Visibility.Hidden;
            JogDistTB.Visibility = Visibility.Hidden;
            DistJogText.Visibility = Visibility.Hidden;
            PaceJogText.Visibility = Visibility.Hidden;
            TimeJogText.Visibility = Visibility.Hidden;
            JogPaceMinTB.Visibility = Visibility.Hidden;
            JogPaceSecTB.Visibility = Visibility.Hidden;
            JogTimeHourTB.Visibility = Visibility.Hidden;
            JogTimeMinTB.Visibility = Visibility.Hidden;
            JogTimeSecTB.Visibility = Visibility.Hidden;
            AddWorkout.Visibility = Visibility.Hidden;
        }

        private void JogCB_Checked(object sender, RoutedEventArgs e)
        {
            JogDistTB.Visibility = Visibility.Visible;
            DistJogText.Visibility = Visibility.Visible;
            PaceJogText.Visibility = Visibility.Visible;
            TimeJogText.Visibility = Visibility.Visible;
            JogPaceMinTB.Visibility = Visibility.Visible;
            JogPaceSecTB.Visibility = Visibility.Visible;
            JogTimeHourTB.Visibility = Visibility.Visible;
            JogTimeMinTB.Visibility = Visibility.Visible;
            JogTimeSecTB.Visibility = Visibility.Visible;
        }

        private void JogCB_Unchecked(object sender, RoutedEventArgs e)
        {
            JogDistTB.Visibility = Visibility.Hidden;
            DistJogText.Visibility = Visibility.Hidden;
            PaceJogText.Visibility = Visibility.Hidden;
            TimeJogText.Visibility = Visibility.Hidden;
            JogPaceMinTB.Visibility = Visibility.Hidden;
            JogPaceSecTB.Visibility = Visibility.Hidden;
            JogTimeHourTB.Visibility = Visibility.Hidden;
            JogTimeMinTB.Visibility = Visibility.Hidden;
            JogTimeSecTB.Visibility = Visibility.Hidden;
        }

        private void UpdateRuns()
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM Runs WHERE Runner = @Runner", cs);
            da.SelectCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.SelectCommand.ExecuteNonQuery();
            cs.Close();
            ds.Clear();
            da.Fill(ds);
            dg.ItemsSource = ds.DefaultView;
        }

        private void UpdateWeek()
        {
            ds.Clear();
            da.SelectCommand = new SqlCommand("SELECT * FROM Runs WHERE Runner = @Runner AND dateofrun >= DATEADD(day, -7, GETDATE())", cs);
            da.SelectCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.SelectCommand.ExecuteNonQuery();
            cs.Close();
            da.Fill(ds);
            dg.ItemsSource = ds.DefaultView;
        }

        private void ViewRuns_Click(object sender, RoutedEventArgs e)
        {
            UpdateRuns();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            newUser.Username = UsernameTB.Text;
            ds.Clear();
            da.InsertCommand = new SqlCommand("IF NOT EXISTS (SELECT * FROM Users WHERE username = @user) INSERT INTO Users VALUES (@username)", cs);
            da.InsertCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = newUser.Username;
            da.InsertCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();

            UpdateWeek();

            UsernameText.Visibility = Visibility.Hidden;
            UsernameTB.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            MileageRB.Visibility = Visibility.Visible;
            WorkoutRB.Visibility = Visibility.Visible;
            NewTitle.Visibility = Visibility.Visible;
            Total.Visibility = Visibility.Visible;
            TotalWeek.Visibility = Visibility.Visible;
            ThisWeek.Visibility = Visibility.Visible;
            ViewRuns.Visibility = Visibility.Visible;
            SwitchUser.Visibility = Visibility.Visible;
        }

        private void ThisWeek_Click(object sender, RoutedEventArgs e)
        {
            UpdateWeek();
        }

        private void SwitchUser_Click(object sender, RoutedEventArgs e)
        {
            ds.Clear();
            UsernameText.Visibility = Visibility.Visible;
            UsernameTB.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            DistanceTB.Visibility = Visibility.Hidden;
            DistanceText.Visibility = Visibility.Hidden;
            TimeText.Visibility = Visibility.Hidden;
            HourTB.Visibility = Visibility.Hidden;
            MinTB.Visibility = Visibility.Hidden;
            SecTB.Visibility = Visibility.Hidden;
            PaceText.Visibility = Visibility.Hidden;
            PaceTB.Visibility = Visibility.Hidden;
            PaceMinTB.Visibility = Visibility.Hidden;
            AddMileageRun.Visibility = Visibility.Hidden;
            NumIntText.Visibility = Visibility.Hidden;
            NumIntTB.Visibility = Visibility.Hidden;
            DistIntText.Visibility = Visibility.Hidden;
            DistIntTB.Visibility = Visibility.Hidden;
            PaceIntText.Visibility = Visibility.Hidden;
            PaceIntMinTB.Visibility = Visibility.Hidden;
            PaceIntSecTB.Visibility = Visibility.Hidden;
            JogCB.Visibility = Visibility.Hidden;
            JogDistTB.Visibility = Visibility.Hidden;
            DistJogText.Visibility = Visibility.Hidden;
            PaceJogText.Visibility = Visibility.Hidden;
            TimeJogText.Visibility = Visibility.Hidden;
            JogPaceMinTB.Visibility = Visibility.Hidden;
            JogPaceSecTB.Visibility = Visibility.Hidden;
            JogTimeHourTB.Visibility = Visibility.Hidden;
            JogTimeMinTB.Visibility = Visibility.Hidden;
            JogTimeSecTB.Visibility = Visibility.Hidden;
            AddWorkout.Visibility = Visibility.Hidden;
            MileageRB.Visibility = Visibility.Hidden;
            WorkoutRB.Visibility = Visibility.Hidden;
            NewTitle.Visibility = Visibility.Hidden;
        }

        private void Total_Click(object sender, RoutedEventArgs e)
        {
            ds2.Clear();
            da.SelectCommand = new SqlCommand("SELECT SUM(distance) AS Total FROM Runs WHERE Runner = @Runner", cs);
            da.SelectCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.SelectCommand.ExecuteNonQuery();
            cs.Close();
            da.Fill(ds2);
            dg.ItemsSource = ds2.DefaultView;
        }

        private void TotalWeek_Click(object sender, RoutedEventArgs e)
        {
            ds2.Clear();
            da.SelectCommand = new SqlCommand("SELECT SUM(distance) AS Total FROM Runs WHERE Runner = @Runner AND dateofrun >= DATEADD(day, -7, GETDATE())", cs);
            da.SelectCommand.Parameters.Add("@Runner", SqlDbType.VarChar).Value = newUser.Username;
            cs.Open();
            da.SelectCommand.ExecuteNonQuery();
            cs.Close();
            da.Fill(ds2);
            dg.ItemsSource = ds2.DefaultView;
        }
    }
}