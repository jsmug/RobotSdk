using System;

namespace RobotIntegration
{
    public class MethodSignatureEventArgs : EventArgs
    {

        private MethodSignatureEventArgs() : base()
        {
        }

        public MethodSignatureEventArgs(string methodName, params object[] args)
        {
            
            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            MethodSignature = new MethodSignature(methodName, args);

        }


        #region public

        public MethodSignature MethodSignature { get; }

        #endregion

    }

}
