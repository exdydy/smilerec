
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;




namespace Smilecatcher
{
    public partial class Mainform : Form
    {
        HaarCascade facedetector;
        HaarCascade mouthdetector;
        MCvTermCriteria faceCriteria;
        MCvTermCriteria mouthCriteria;
        double criteria = 0.001;
        Image smileimage;
        Image sadimage;
        Image<Bgr, byte> frame;
        Capture camera;
        Image<Gray, byte> result;
        Image<Gray, byte> grayface = null;
        Image<Gray, byte> graymouth = null;
        List<Image<Gray, byte>> trainedfaces = new List<Image<Gray, byte>>();
        List<Image<Gray, byte>> trainedmouths = new List<Image<Gray, byte>>();
        List<string> labelsface = new List<string>();
        List<string> labelsmouth = new List<string>();
        int countfaces = 0, countmouths = 0;
        MCvAvgComp[][] facesDetectedNow;
        MCvAvgComp[][] mouthsDetectedNow;

        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);

        public Mainform()
        {
            InitializeComponent();

            
            facedetector = new HaarCascade(Application.StartupPath + "/data/xml/haarcascade_frontalface_default.xml");
            mouthdetector = new HaarCascade(Application.StartupPath + "/data/xml/haarcascade_mcs_mouth.xml");
            try
            {
                countfaces = Directory.GetFiles(Application.StartupPath + "/data/faces/").Length;
                countmouths = Directory.GetFiles(Application.StartupPath + "/data/smiles/").Length + Directory.GetFiles(Application.StartupPath + "/data/sads/").Length;

                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + "/data/faces/", "*.bmp"))
                {
                    trainedfaces.Add(new Image<Gray, byte>(file));
                    labelsface.Add(Path.GetFileNameWithoutExtension(file));
                }

                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + "/data/smiles/", "*.bmp"))
                {
                    trainedmouths.Add(new Image<Gray, byte>(file));
                    labelsmouth.Add("smile");
                }
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + "/data/sads/", "*.bmp"))
                {
                    trainedmouths.Add(new Image<Gray, byte>(file));
                    labelsmouth.Add("sad");
                }
            }
            catch
            {
                MessageBox.Show("Looks like smth went wrong trying to read data files");
            }

            smileimage = Image.FromFile(Application.StartupPath + "/data/smile.png");
            sadimage = Image.FromFile(Application.StartupPath + "/data/sad.png");
            emojipicture.Image = smileimage;
           }

        private void FrameProcessing(object sender, EventArgs e)
        {
            frame = camera.QueryFrame().Resize(640, 360, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayface = frame.Convert<Gray, Byte>();
            facesDetectedNow = grayface.DetectHaarCascade(facedetector, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
            graymouth = frame.Convert<Gray, Byte>();
            mouthsDetectedNow = graymouth.DetectHaarCascade(mouthdetector, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 50));
            foreach (MCvAvgComp f in facesDetectedNow[0])
            {
                result = frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                if (checkBoxface.Checked) frame.Draw(f.rect, new Bgr(Color.Green), 3);
                if(trainedfaces.ToArray().Length !=0)
                {
                    faceCriteria = new MCvTermCriteria(countfaces, criteria);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainedfaces.ToArray(), labelsface.ToArray(), 1500, ref faceCriteria);
                    frame.Draw(recognizer.Recognize(result), ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));
                }
            }
            foreach (MCvAvgComp m in mouthsDetectedNow[0])
            {
                result = frame.Copy(m.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                if (checkBoxmouth.Checked)  frame.Draw(m.rect, new Bgr(Color.Blue), 3);

                if (trainedmouths.ToArray().Length != 0)
                {
                    mouthCriteria = new MCvTermCriteria(countmouths, criteria);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainedmouths.ToArray(), labelsmouth.ToArray(), 1500, ref mouthCriteria);
                    if (recognizer.Recognize(result) == "sad")
                    {
                        emojipicture.Image = sadimage;
                    }
                    else
                    {
                        emojipicture.Image = smileimage;
                    }
                }
            }
            imageBox1.Image = frame;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcessing);
        }

        private void buttonMemorizesmile_Click(object sender, EventArgs e)
        {
            if (mouthsDetectedNow[0].Length == 1)
            {
                trainedmouths.Add(frame.Copy(mouthsDetectedNow[0][0].rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                labelsmouth.Add("smile");
                trainedmouths.ToArray()[countmouths].Save(Application.StartupPath + "/data/smiles/" + Directory.GetFiles(Application.StartupPath + "/data/smiles/").Length + ".bmp");
                countmouths++;
                MessageBox.Show("This smile Added Successfully"); 
            }
            else
            {
                MessageBox.Show("Detected no mouth / more than one mouth");
            }
        }

        private void buttonMemorizesad_Click(object sender, EventArgs e)
        {
            if (mouthsDetectedNow[0].Length == 1)
            {
                trainedmouths.Add(frame.Copy(mouthsDetectedNow[0][0].rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                labelsmouth.Add("sad");
                trainedmouths.ToArray()[countmouths].Save(Application.StartupPath + "/data/sads/" + Directory.GetFiles(Application.StartupPath + "/data/sads/").Length + ".bmp");
                countmouths++;
                MessageBox.Show("This sad Added Successfully");
            }
            else
            {
                MessageBox.Show("Detected no mouth / more than one mouth");
            }
        }

        private void buttonMemorizeface_Click(object sender, EventArgs e)
        {
            if (facesDetectedNow[0].Length == 1)
            {
                trainedfaces.Add(frame.Copy(facesDetectedNow[0][0].rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                labelsface.Add(textBox1.Text);
                trainedfaces.ToArray()[countfaces].Save(Application.StartupPath + "/data/faces/" + textBox1.Text + ".bmp");
                File.AppendAllText(Application.StartupPath + "/data/Faces.txt", labelsface.ToArray()[countfaces] + ",");
                countfaces++;
                MessageBox.Show(textBox1.Text + " Added Successfully");
            }
               else
            {
                MessageBox.Show("Detected no faces / more than one face");
            }
        }
    }
}
