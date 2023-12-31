﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLessonShmachilin.Infrastructure.Command
{
    class RelayCommand : BaseCommand
    {
        private readonly RelayCommand _command;
        private readonly Action<object> _Execute;
        private readonly Func<object,bool> _CanExecute;
        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null) 
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parametr) => _CanExecute?.Invoke(parametr) ?? true;
        public override void Execute(object? parameter) => _Execute(parameter);
    }
}
