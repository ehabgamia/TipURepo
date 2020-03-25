using System;
using System.Collections.Generic;
using System.Linq;
using VideoBrek.Base;
namespace VideoBrek.Validator
{

    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        private List<IValidationRule<T>> _validations;

        private List<string> _errors;
        private T _value;
        private bool _isValid;
        public List<IValidationRule<T>> Validations => _validations;
        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }


    }
    public interface IValidity
    {
        bool IsValid { get; set; }
    }
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }

    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return !string.IsNullOrWhiteSpace(str);
        }
    }

}