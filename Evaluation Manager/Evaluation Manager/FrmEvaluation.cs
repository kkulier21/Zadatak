using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmEvaluation : Form
    {
        private Student student;

        

        public FrmEvaluation(Student selectedStudent)
        {
            InitializeComponent();
            student = selectedStudent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMinForGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmEvaluation_Load(object sender, EventArgs e)
        {
            SetFormText();
            var activities = ActivityRepository.GetActivities();
            cboActivities.DataSource = activities;
        }
        private void SetFormText()
        {
            Text = student.FirstName + " " + student.LastName;
        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var evaluation =
             EvaluationRepository.GetEvaluation(SelectedStudent, currentActivity);
            if (evaluation != null)
            {
                txtTeacher.Text = evaluation.Evaluator.ToString();
                txtEvaluationDate.Text = evaluation.EvaluationDate.ToString();
                numPoints.Value = evaluation.Points;
            }
            else
            {
                txtTeacher.Text = FrmLogin.LoggedTeacher.ToString();
                txtEvaluationDate.Text = "-";
                numPoints.Value = 0;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtActivityDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
