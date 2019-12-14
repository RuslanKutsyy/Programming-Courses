using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        public int barrelCapacity = bulletsPerBarrel;

        public Pistol(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel >= 1)
            {
                this.BulletsPerBarrel -= 1;
                if (this.BulletsPerBarrel == 0 && this.TotalBullets >= this.barrelCapacity)
                {
                    this.BulletsPerBarrel = this.barrelCapacity;
                    this.TotalBullets -= this.barrelCapacity;
                }
                else if (this.BulletsPerBarrel == 0 && this.TotalBullets < this.barrelCapacity)
                {
                    this.BulletsPerBarrel = this.TotalBullets;
                }
                return 1;
            }
            return 0;
        }
    }
}
