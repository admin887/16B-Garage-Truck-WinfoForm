using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texture
{
    public class Terrain
    {
        public const string k_Asfalt = @"Texture\asfalto.jpg";
        public const string k_Grass = @"Texture\grass.jpg";
        public const string k_Top = @"Texture\top.jpg";
    }
    public class Front
    {
        public const string k_FrontSide = @"Texture\Front_front.jpg";
        public const string k_BackSide = @"Texture\Front_Back.jpg";
        public const string k_RightSide = @"Texture\Front_Right.jpg";
        public const string k_LeftSide = @"Texture\Front_Left.jpg";
        public const string k_FrontRightWheel = @"Texture\Wheel.png";
        public const string k_FrontLeftWheel = @"Texture\Wheel.png";

        private Front() { }
    }

    public class Back
    {
        public const string k_FrontSide = @"Texture\Back_front.jpg";
        public const string k_BackSide = @"Texture\Back_Back.jpg";
        public const string k_RightSide = @"Texture\Back_Right.jpg";
        public const string k_LeftSide = @"Texture\Back_Left.jpg";
        public const string k_BackRightWheel = @"Texture\Wheel.png";
        public const string k_BackLeftWheel = @"Texture\Wheel.png";

        private Back() { }
    }


}
