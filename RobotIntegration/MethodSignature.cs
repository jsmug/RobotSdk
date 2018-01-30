using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotIntegration
{
    public class MethodSignature
    {

        private readonly List<object> _arguments = new List<object>();


        private MethodSignature()
        {
        }

        public MethodSignature(string methodName, params object[] args)
        {

            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            MethodName = methodName;

            if (args != null)
            {
                _arguments.AddRange(args);
            }

        }


        #region public

        public IEnumerable<object> Arguments => _arguments.Skip(0);

        public string MethodName { get; } 

        #endregion

    }

}
