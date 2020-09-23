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

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        UndergraduateStudent Student = new UndergraduateStudent();
        GraduateStudent Grad = new GraduateStudent();
        Course course = new Course();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text.Equals("") || LastNameTextBox.Text.Equals("") || StudentIDTextBox.Text.Equals("")
                    || AgeTextBox.Text.Equals(""))
            {
                string messageBoxText = "All fields must be filled out.";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            ListBoxItem studentListBoxItem = new ListBoxItem();
            studentListBoxItem.Content = LastNameTextBox.Text + " " + FirstNameTextBox.Text;
            StudentsListBox.Items.Add(studentListBoxItem);

            course.Courses.Add(new List<Course>());

            if (Undergraduate.IsSelected == true)
            {
                try
                {
                    Student.PersonList.Add(new UndergraduateStudent());
                    Student.UndergradStudentID.Add(StudentIDTextBox.Text);
                    Grad.GradStudentID.Add("null");
                }
                catch (Exception ex)
                {
                    string messageBoxText = ex.ToString();
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                try
                {
                    Student.PersonList.Add(new GraduateStudent());
                    Grad.GradStudentID.Add(StudentIDTextBox.Text);
                    Student.UndergradStudentID.Add("null");
                }
                catch (Exception ex)
                {
                    string messageBoxText = ex.ToString(); ;
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }

            try
            {
                Student.PersonList[Student.PersonList.Count - 1].FirstName = FirstNameTextBox.Text;
                Student.PersonList[Student.PersonList.Count - 1].LastName = LastNameTextBox.Text;

                if (Male.IsSelected == true)
                {
                    Student.PersonList[Student.PersonList.Count - 1].Gender = 0;
                }
                else if (Female.IsSelected == true)
                {
                    Student.PersonList[Student.PersonList.Count - 1].Gender = 1;
                }
                else
                {
                    Student.PersonList[Student.PersonList.Count - 1].Gender = 2;
                }
                Student.PersonList[Student.PersonList.Count - 1].Age = int.Parse(AgeTextBox.Text);
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.ToString(); ;
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }

        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                FirstNameTextBox.Text = Student.PersonList[StudentsListBox.SelectedIndex].FirstName;
                LastNameTextBox.Text = Student.PersonList[StudentsListBox.SelectedIndex].LastName;

                if (Student.UndergradStudentID[StudentsListBox.SelectedIndex].Equals("null"))
                {
                    Graduate.IsSelected = true;
                    StudentIDTextBox.Text = Grad.GradStudentID[StudentsListBox.SelectedIndex];
                }
                else
                {
                    Undergraduate.IsSelected = true;
                    StudentIDTextBox.Text = Student.UndergradStudentID[StudentsListBox.SelectedIndex];
                }

                if (Student.PersonList[StudentsListBox.SelectedIndex].Gender == 0)
                {
                    Male.IsSelected = true;
                }
                else if (Student.PersonList[StudentsListBox.SelectedIndex].Gender == 1)
                {
                    Female.IsSelected = true;
                }
                else
                {
                    Other.IsSelected = true;
                }

                AgeTextBox.Text = Student.PersonList[StudentsListBox.SelectedIndex].Age.ToString();

                ShowCourseList();

                double totalGPA = CalculateGPA();
                TotalGPATextBox.Text = totalGPA.ToString();
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.ToString();
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsListBox.SelectedIndex == -1)
            {
                string messageBoxText = "Please select a student";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            if (CourseNameTextBox.Text.Equals("") || CourseNumberTextBox.Text.Equals("") ||
                CreditHoursTextBox.Text.Equals("") || GPATextBox.Text.Equals(""))
            {
                string messageBoxText = "All fields must be filled out.";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            if(double.Parse(GPATextBox.Text) < 0.0 || double.Parse(GPATextBox.Text) > 4.0)
            {
                string messageBoxText = "GPA must be in the range 0.0-4.0.";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            if (Student.UndergradStudentID[StudentsListBox.SelectedIndex].Equals("null"))
            {
                if (int.Parse(CourseNumberTextBox.Text) < 5000 || int.Parse(CourseNumberTextBox.Text) > 9999)
                {
                    string messageBoxText = "Course Number 5000-9999 are graduate courses.";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }

            }
            else
            {
                if (int.Parse(CourseNumberTextBox.Text) < 1000 || int.Parse(CourseNumberTextBox.Text) > 4999)
                {
                    string messageBoxText = "Course Number 1000-4999 are undergraduate courses.";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
            }

            try
            {
                course.Courses[StudentsListBox.SelectedIndex].Add(new Course());

                int index = course.Courses[StudentsListBox.SelectedIndex].Count - 1;

                course.Courses[StudentsListBox.SelectedIndex].ElementAt(index).CourseName = CourseNameTextBox.Text;
                course.Courses[StudentsListBox.SelectedIndex].ElementAt(index).CourseNumber = int.Parse(CourseNumberTextBox.Text);
                course.Courses[StudentsListBox.SelectedIndex].ElementAt(index).CreditHours = int.Parse(CreditHoursTextBox.Text);
                course.Courses[StudentsListBox.SelectedIndex].ElementAt(index).GPA = double.Parse(GPATextBox.Text);
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.ToString();
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            double totalGPA = CalculateGPA();
            TotalGPATextBox.Text = totalGPA.ToString();
            ShowCourseList();

        }

        void ShowCourseList()
        {
            try
            {
                if (course.Courses[StudentsListBox.SelectedIndex] != null)
                {
                    CoursessListBox.Items.Clear();

                    for (int i = 0; i < course.Courses[StudentsListBox.SelectedIndex].Count; i++)
                    {
                        ListBoxItem courseListBoxItem = new ListBoxItem();
                        courseListBoxItem.Content = course.Courses[StudentsListBox.SelectedIndex].ElementAt(i).CourseName;
                        CoursessListBox.Items.Add(courseListBoxItem);

                    }
                }
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.ToString();
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void CoursessListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CoursessListBox.SelectedIndex == -1)
            {
                CourseNameTextBox.Text = "";
                CourseNumberTextBox.Text = "";
                CreditHoursTextBox.Text = "";
                GPATextBox.Text = "";
                return;
            }
            try
            {
                CourseNameTextBox.Text = course.Courses[StudentsListBox.SelectedIndex].ElementAt(CoursessListBox.SelectedIndex).CourseName;
                CourseNumberTextBox.Text = course.Courses[StudentsListBox.SelectedIndex].ElementAt(CoursessListBox.SelectedIndex).CourseNumber.ToString();
                CreditHoursTextBox.Text = course.Courses[StudentsListBox.SelectedIndex].ElementAt(CoursessListBox.SelectedIndex).CreditHours.ToString();
                GPATextBox.Text = course.Courses[StudentsListBox.SelectedIndex].ElementAt(CoursessListBox.SelectedIndex).GPA.ToString();
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.ToString();
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        double CalculateGPA()
        {
            double numerator = 0;
            double totalCreditHours = 0; 

            for(int i = 0; i < course.Courses[StudentsListBox.SelectedIndex].Count; i++)
            {
                numerator = numerator + (course.Courses[StudentsListBox.SelectedIndex].ElementAt(i).GPA *
                                    course.Courses[StudentsListBox.SelectedIndex].ElementAt(i).CreditHours);

                totalCreditHours = totalCreditHours + course.Courses[StudentsListBox.SelectedIndex].ElementAt(i).CreditHours;
            }

            double totalGPA = numerator / totalCreditHours;

            return totalGPA;
        }
    }
}
