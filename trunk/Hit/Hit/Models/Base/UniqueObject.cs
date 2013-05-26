namespace Hit.Models.Base
{
    public abstract class UniqueObject : DataObject
    {
        public virtual int Id
        {
            get; 
            set;
        }

        public virtual bool IsNew
        {
            get;
            set;
        }
    }
}
