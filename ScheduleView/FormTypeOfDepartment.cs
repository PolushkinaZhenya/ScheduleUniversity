﻿using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
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
    public partial class FormTypeOfDepartment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ITypeOfDepartmentService service;
        private int? id;

        public FormTypeOfDepartment(ITypeOfDepartmentService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTypeOfDepartment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TypeOfDepartmentViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxType.Text = view.Title;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new TypeOfDepartmentBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxType.Text
                    });
                }
                else
                {
                    service.AddElement(new TypeOfDepartmentBindingModel
                    {
                        Title = textBoxType.Text
                    });
                }
                //MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
