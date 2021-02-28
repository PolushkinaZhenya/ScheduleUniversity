using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void кафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDepartments>();
            form.ShowDialog();
        }

        private void учебныеКорпусаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEducationalBuildings>();
            form.ShowDialog();
        }

        private void времяПереходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTransitionTimes>();
            form.ShowDialog();
        }

        private void аудиторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuditoriums>();
            form.ShowDialog();
        }

        private void времяПроведенияПарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClassTimes>();
            form.ShowDialog();
        }

        private void типыАудиторийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfAudiences>();
            form.ShowDialog();
        }

        private void типыКафедрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfDepartments>();
            form.ShowDialog();
        }
    }
}
