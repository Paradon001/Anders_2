using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Anders_2.Models;

namespace Anders_2.ViewModels
{
    public class DashboardCarouselViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Carouselview> CarouselViews { get; } = new();

        public DashboardCarouselViewModel()
        {
            CarouselViews.Add(new Carouselview
            {
                Title = "You are Excellent",
                Description = "You are excellent and you can do anything you want to do. You are capable of achieving your goals and dreams. Believe in yourself and keep pushing forward.",
                Image = "lucytwo.jpg"
            });
            CarouselViews.Add(new Carouselview
            {
                Title = "You are a christian",
                Description = "You are excellent and you can do anything you want to do. You are capable of achieving your goals and dreams. Believe in yourself and keep pushing forward.",
                Image = "mtstotwee.png"
            });
            CarouselViews.Add(new Carouselview
            {
                Title = "You are healthy",
                Description = "You are excellent and you can do anything you want to do. You are capable of achieving your goals and dreams. Believe in yourself and keep pushing forward.",
                Image = "lucy.jpg"
            });
            CarouselViews.Add(new Carouselview
            {
                Title = "You are Excellent",
                Description = "You are excellent and you can do anything you want to do. You are capable of achieving your goals and dreams. Believe in yourself and keep pushing forward.",
                Image = "leonandkaira.png"
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


}

