using System;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Contract
{
    public interface IStatus
    {
        void TrackStatus(AppProgress statusOf);
    }
}