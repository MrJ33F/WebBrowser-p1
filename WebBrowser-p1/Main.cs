﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser_p1
{
    public partial class Main : Form
    {

        private bool mouseDown;
        private Point lastMouseLocation;
        private bool isMaximized = false;
        private bool isHidden;

        public Main()
        {
            InitializeComponent();
            isHidden = true;

            mainWebBrowser.Navigate("https://www.google.com");
            widgetsWebBrowser.Visible = false;
        }

  

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void widgetsPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.widgetsPanel.ClientRectangle, Color.Aquamarine, ButtonBorderStyle.Solid);
        }

        private void webBrowserToolBar_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void webBrowserMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowserToolBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastMouseLocation = e.Location;
        }

        private void webBrowserToolBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                        (this.Location.X - lastMouseLocation.X) + e.X, (this.Location.Y - lastMouseLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void webBrowserToolBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void mainWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.BackColor = Color.FromArgb(31, 0, 54);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.searchPanel.ClientRectangle, Color.Aquamarine, ButtonBorderStyle.Solid);
        }

        private void fullscreenButton_Click(object sender, EventArgs e)
        {
            if(isMaximized == false)
            {
                this.WindowState = FormWindowState.Maximized;
                isMaximized = true;
            }
            else if(isMaximized == true)
            {
                this.WindowState = FormWindowState.Normal;
                isMaximized = false;
            }
        }

        private void instagramButton_Click(object sender, EventArgs e)
        {
            slidePanelTimer.Start();
            widgetsWebBrowser.Visible = true;
            widgetsWebBrowser.Navigate("https://www.instagram.com");
        }
        private void slidePanelTimer_Tick(object sender, EventArgs e)
        {
            if (isHidden)
            {
                widgetsPanel.Width = widgetsPanel.Width + 100;
                if(widgetsPanel.Width >= 600)
                {
                    slidePanelTimer.Stop();
                    isHidden = false;
                    this.Refresh();
                }
            }
            else
            {
                widgetsPanel.Width = widgetsPanel.Width - 100;
                if (widgetsPanel.Width <= 60)
                {
                    widgetsWebBrowser.Visible = false;
                    slidePanelTimer.Stop();
                    isHidden = true;
                    this.Refresh();
                }
            }
        }

        private void messengerButton_Click(object sender, EventArgs e)
        {
            slidePanelTimer.Start();
            widgetsWebBrowser.Visible = true;
            widgetsWebBrowser.Navigate("https://www.facebook.com/messages");
        }

        private void discordButton_Click(object sender, EventArgs e)
        {
            slidePanelTimer.Start();
            widgetsWebBrowser.Visible = true;
            widgetsWebBrowser.Navigate("https://discord.com/login");
        }

        private void whatsappButton_Click(object sender, EventArgs e)
        {
            slidePanelTimer.Start();
            widgetsWebBrowser.Visible = true;
            widgetsWebBrowser.Navigate("https://web.whatsapp.com");
        }
    }
}
