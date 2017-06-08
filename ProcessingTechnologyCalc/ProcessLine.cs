﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using System.ComponentModel;
using System.Drawing;

namespace ProcessingTechnologyCalc
{
    //-------------------------------------------------------------------      отрезок   --------------------------
    public class ProcessObjectLine : ProcessObject
    {
        private static int last_no;

        public ProcessObjectLine(Curve acadObject, ProcessOptions processOptions)
            : base(acadObject, processOptions)
        {
            ObjectName = "Отрезок" + (++last_no).ToString();
            TypeName = "Отрезок";
            ObjectType = ObjectType.Line;
        }

        public override double Length
        {
            get
            {
                return ProcessLine.Length;
            }
        }
        [CategoryAttribute("2. Геометрия объекта"), DisplayName("Угол"), DescriptionAttribute("Угол отрезка в градусах")]
        public double Angle
        {
            get
            {
                return Math.Round(ProcessLine.Angle * 180 / Math.PI, 3);
            }
        }
        [CategoryAttribute("3. Геометрия траектории"), DisplayName("Длина"), DescriptionAttribute("Длина отрезка")]
        public double ToolpathLength
        {
            get
            {
                return ToolpathCurve != null ? ToolpathLine.Length : 0;
            }
        }
        [CategoryAttribute("3. Геометрия траектории"), DisplayName("Угол фрезы"), DescriptionAttribute("Угол фрезы в градусах")]
        public double ToolpathAngle
        {
            get
            {
                return ToolpathCurve != null ? Math.Round(((Math.PI * 2 - ToolpathLine.Angle) % Math.PI) * 180 / Math.PI, 3) : 0;
                //Math.Round((ToolpathCurve as Line).Angle * 180 / Math.PI, 3) 
            }
        }
    }
}