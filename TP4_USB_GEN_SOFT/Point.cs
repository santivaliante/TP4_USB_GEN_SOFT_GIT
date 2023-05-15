using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_USB_GEN_SOFT
{
    class Point
    {
        // Décalaration des proprietés
        private double dV_PointX;  // Coordonnés pour la direcction
        private double dV_PointY;  // Coordonnés pour la distance

        // Constructeur
        public Point()
        {
            // Initialisation des variables privées
            dV_PointX = 0;
            dV_PointY = 0;
        }
        // Surcharge du constructeur avec paramètres
        public Point(double Position, double Value)
        {
            // Initialisation des variables privées
            dV_PointX = Position;
            dV_PointY = Value;
        }

        // Accesseurs
        public double GetValue()
        {
            return dV_PointY;
        }
        public void SetValue(double Value)
        {
            dV_PointY = Value;
        }
        public double GetPosition()
        {
            return dV_PointX;
        }
        public void SetPosition(double Position)
        {
            dV_PointX = Position;
        }
    }
}
