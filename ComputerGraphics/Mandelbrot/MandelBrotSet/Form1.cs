�L��o|��*��c^r
Q�6�I��}��C:���Pg�������$@�~f�lO~�_��06���e�B�M�u���`� �*��Ue9�Z�x���T��7�R�?2�JԷ��[q���[�,+�?�ⲫ�pp)02j�Ӝ�ڱ2�`���&�ҁ�@a,�Ԥ떃a����D/�����?���I��,���09����
�֍�y:��8Ym@�q�Mk�c ЛI��T�с����tuLH6봩[���}�mܵ(���$�����+W�h��ͻ����E���Xv�C��J/��,�'�וE�1^��M�A�������P�/���_2!`�^���^�I(jn%���� {b1�LĘm<�>=Ȅ��)"����d��*�22�D}�[{�/M8��C��������;��;6�Pkewͩ�'�9+t�w���*��oA�OD�i{f*Q�#���	�b�>i/��wo6�R ���M0����{��6��h�1f|���*ӘÐ棻U�:�+-p�g��R��t�$�8���Z=��m=Q�.�!���	�ش���2��Y��>��E6 !C���ŵ�Or�5>��3D!4�3A7�D;5=#:�����y��7>?�8$L��F��os��)޿ᯎsot���>�'�Vb�M�p�����d���E���+��*��ƅ���pl�ӿgγg/���ׁH�a��\l](�eN�y��
k�ZU��V�ё
����~����-���Sw F�M�7�f�?WX�駰�\z�OkM�2V쉀5����P�6���~Ag�{�u����[�&,���z,�h d"�܅?�	>{���vr�qeF�!%qB��a����B�kg2<��rp9&�����q���S�ӷ}�S�l��Q[~jb4B�ѻ���/���IN'2�.t��u|e�C�x�� �0�Hf��R�N�䘌�	�7NJ����S���W��������}I!�*�n�51�.Parse(textBox1.Text);
                p = Cursor.Position;
                this.PointToClient(p);
               
            }
            else
            { check = false; }
            
            

            pictureBox1.Invalidate();
        }
        public void Equation(double x, double y,  int color)
        {


            int i;
            double xn = 0,yn = 0;
            double xn1, yn1;
            double mag = 0;
            
            for(i = 0;i<=1024 && mag < 50; i++)
            {
                xn1 = (xn * xn) - (yn * yn) + x;
                yn1 = (2 * xn * yn) + y;
                mag = (xn1 * xn1) + (yn1 * yn1);
                xn = xn1;
                yn = yn1;
            }
            color1 = i;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            
            
            int xlim = pictureBox1.Size.Width;
            int ylim = pictureBox1.Size.Height;
            double C0;
            double C1;
            Color setcolor = Color.FromArgb(color1, color1, color1);
            SolidBrush aBrush = new SolidBrush(setcolor);
            Graphics g = e.Graphics;
            color1 = 0;
            double temp;

            if (check != true)
            {
                C0VarMin = -2;
                C0VarMax = 2;
                C1VarMin = -2;
                C1VarMax = 2;
                dx = C0VarMax - C0VarMin;
                dx = dx / xlim;
                dy = C1VarMax - C1VarMin;
                dy = dy / ylim;
            }
            else
            {
                int pointx, pointy;
                pointx = p.X;
                pointy = p.Y;
                C0VarMin = C0VarMin + ((p.X - (size / 2)) * dx);               
                C1VarMin = C1VarMin + ((p.Y - (size / 2)) * dy);
                C0VarMax = C0VarMin + size;
                C1VarMax = C1VarMin + size;
                temp = C0VarMax - C0VarMin;
                dx = temp / pictureBox1.Size.Width;
                temp = C1VarMax - C1VarMin;
                dy = temp / pictureBox1.Size.Height;
            }


            for (int i = 0; i <= xlim; i++)
            {
                for(int j = 0; j<= ylim;j++)
                {
                    C0 = C0VarMin + (i * dx);
                    C1 = C1VarMin + (j * dy);
                    
                    Equation(C0, C1, color1);
                    if(color1 >255)
                    {
                        color1 = 255;
                    }
                     int colorp= color1;
                    aBrush.Color = Color.FromArgb(color1, color1, color1);
                    g.FillRectangle(aBrush,i, j, 1, 1);
                }
            }
        }
    }
}
