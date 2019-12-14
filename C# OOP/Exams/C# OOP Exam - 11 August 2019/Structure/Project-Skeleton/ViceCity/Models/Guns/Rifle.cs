using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;
        public int barrelCapacity = bulletsPerBarrel;

        public Rifle(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel >= 5)
            {
                this.BulletsPerBarrel -= 5;
                return 5;
            }
            else
            {
                if (this.BulletsPerBarrel < 5 && this.TotalBullets >= this.barrelCapacity)
                {
                    int needed = this.BulletsPerBarrel;
                    this.BulletsPerBarrel = 0;
                    int left = 5 - needed;

                    this.BulletsPerBarrel = this.barrelCapacity - left;
                    this.TotalBullets -= this.barrelCapacity;
                    return 5;

                }
                else
                {
                    int needed = this.BulletsPerBarrel;
                    this.BulletsPerBarrel = 0;
                    int left = 5 - needed;
                    this.BulletsPerBarrel = this.TotalBullets;
                    this.TotalBullets = 0;

                    if (this.BulletsPerBarrel >= left)
                    {
                        this.BulletsPerBarrel -= left;
                        return 5;
                    }
                    else
                    {
                        int toReturn = needed + this.BulletsPerBarrel;
                        this.BulletsPerBarrel = 0;
                        return toReturn;
                    }
                }
            }
        }
    }
}
