﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
        }
        /*
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }
        
        public class Run
        {
            public int Distance { get; set; }
            public TimeSpan Pace { get; set; }
            public double Hour { get; set; }
            public double Minute { get; set; }
            public double Second { get; set; }
            public string Date { get; set; }
            public TimeSpan Time { get; set; }


            public string Type { get; set; }
            double distance;
            double hour, minute, second;
            double pace;
        }
        
        public class MileageRun : Run
        {

        }

        public class Workout : Run
        {

        }
        */
        private void AddMileageRun_Click(object sender, RoutedEventArgs e)
        {
            var mileage = new MileageRun
            {
                Distance = Convert.ToInt32(DistanceTB.Text),
                Pace = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text)),
                Time = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text)),
                Hour = Convert.ToDouble(HourTB.Text),
                Minute = Convert.ToDouble(MinTB.Text),
                Second = Convert.ToDouble(SecTB.Text),
                Date = Date.Text,
                Type = "Mileage"
            };

            RunLog.Items.Add(mileage);

            //RunLog.ItemsSource = items;

            //TimeSpan time = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text));
            //TimeSpan pacetime = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text));

            SqlConnection cs = new SqlConnection("Data Source=R6507002; Initial Catalog=RunTracker; Integrated Security=TRUE");
            SqlDataAdapter da = new SqlDataAdapter();
            //da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES(@distance)", cs);
            //da.InsertCommand.Parameters.Add("@distance", SqlDbType.Int).Value = Convert.ToInt32(DistanceTB.Text);
            //da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES ('" + DistanceTB.Text + "','" + time + "','" + PaceTB.Text + "','" + Date.Text + "' )", cs);
            da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES (@distance, @totaltime, @pace, @dateofrun)", cs);
            da.InsertCommand.Parameters.Add("@distance", SqlDbType.Int).Value = Convert.ToInt32(DistanceTB.Text);
            da.InsertCommand.Parameters.Add("@totaltime", SqlDbType.Time).Value = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text));
            da.InsertCommand.Parameters.Add("@pace", SqlDbType.Time).Value = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text));
            da.InsertCommand.Parameters.Add("@dateofrun", SqlDbType.Date).Value = Date.Text;
            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();

            MessageBox.Show("New Run added!");
        }

        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new MileageRun()
            {
                Distance = Convert.ToInt32(DistanceTB.Text),
                Pace = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text)),
                Time = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text)),
                Hour = Convert.ToDouble(HourTB.Text),
                Minute = Convert.ToDouble(MinTB.Text),
                Second = Convert.ToDouble(SecTB.Text),
                Date = Date.Text,
                Type = "Mileage"
            });
            RunLog.ItemsSource = items;

            TimeSpan time = new TimeSpan(Convert.ToInt32(HourTB.Text), Convert.ToInt32(MinTB.Text), Convert.ToInt32(SecTB.Text));
            TimeSpan pacetime = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text));

            SqlConnection cs = new SqlConnection("Data Source=R6507002; Initial Catalog=RunTracker; Integrated Security=TRUE");
            SqlDataAdapter da = new SqlDataAdapter();
            //da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES ('" + DistanceTB.Text + "','" + time + "','" + PaceTB.Text + "','" + Date.Text + "' )", cs);
            da.InsertCommand = new SqlCommand("INSERT INTO Runs VALUES (@distance, @totaltime, @pace, @dateofrun)", cs);
            da.InsertCommand.Parameters.Add("@distance", SqlDbType.Int).Value = Convert.ToInt32(DistanceTB.Text);
            da.InsertCommand.Parameters.Add("@totaltime", SqlDbType.Time).Value = time;
            da.InsertCommand.Parameters.Add("@pace", SqlDbType.Time).Value = new TimeSpan(0, Convert.ToInt32(PaceTB.Text), Convert.ToInt32(PaceMinTB.Text));
            da.InsertCommand.Parameters.Add("@dateofrun", SqlDbType.Date).Value = Date.Text;

            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();

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
            Date.Visibility = Visibility.Hidden;
            AddMileageRun.Visibility = Visibility.Hidden;
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
        }
    }
}