﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SimpleUWPTraineeProject.Convertors
{
    public class TrueToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}