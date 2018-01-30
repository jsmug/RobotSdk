using RobotSdk;
using System;

namespace RobotIntegration
{

    public class IdentifiableRobot : IIdentifiableRobot, IEquatable<IIdentifiableRobot>
    {

        private IdentifiableRobot()
        {
        }

        public IdentifiableRobot(string id, string name, IRobot robot)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            { 
                throw new ArgumentNullException(nameof(name));
            }

            Id = id;
            Name = name;
            Robot = robot ?? throw new ArgumentNullException(nameof(robot));

        }


        #region public

        public string Id { get; }

        public string Name { get; }

        public IRobot Robot { get; }


        public override bool Equals(object obj)
        {

            bool equals = false;

            if (ReferenceEquals(null, obj) || obj.GetType() != GetType())
            {
                equals = false;
            }
            else if (ReferenceEquals(this, obj))
            {
                equals = true;
            }
            else
            {
                equals = Equals(obj as IIdentifiableRobot);
            }

            return equals;

        }

        public bool Equals(IIdentifiableRobot other)
        {

            bool equals = false;

            if (other != null)
            {

                equals = CheckStringPropertiesMatches(other.Id, Id)
                    && CheckStringPropertiesMatches(other.Name, Name)
                    && other.Robot == Robot;

            }

            return equals;

        }

        public override int GetHashCode()
        {

            int hash = 17;
            int hashMultiplier = 23;

            unchecked
            {

                hash = hash * hashMultiplier + Id.GetHashCode();
                hash = hash * hashMultiplier + Name.GetHashCode();
                hash = hash * hashMultiplier + Robot.GetHashCode();

                return hash;

            }

        }

        #endregion

        #region private

        private bool CheckStringPropertiesMatches(string a, string b)
        {

            bool matches = a == null && b == null;

            if (!matches)
            {

                if (a != null)
                {
                    matches = a.Equals(b, StringComparison.Ordinal);
                }

            }

            return matches;

        }

        #endregion

    }

}
