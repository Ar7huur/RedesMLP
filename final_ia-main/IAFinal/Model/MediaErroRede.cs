﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class MediaErroRede
    {

        private int pos;
        private double mediaErroRede;

        public MediaErroRede(int pos, double mediaErroRede)
        {
            this.pos = pos;
            this.mediaErroRede = mediaErroRede;
        }

        public int getPos()
        {
            return pos;
        }

        public void setPos(int pos)
        {
            this.pos = pos;
        }

        public double getMediaErroRede()
        {
            return mediaErroRede;
        }

        public void setMediaErroRede(double mediaErroRede)
        {
            this.mediaErroRede = mediaErroRede;
        }
    }
}
