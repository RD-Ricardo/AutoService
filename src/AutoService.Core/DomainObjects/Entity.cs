﻿namespace AutoService.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public void SetCreationDate() => CreationDate = DateTime.Now;
        public void SetUpdateDate() => UpdateDate = DateTime.Now;

        #region Comparisons

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
