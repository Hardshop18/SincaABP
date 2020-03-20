namespace Volo.Abp.TestApp2.Domain
{
    public class PersonNameChangedEvent
    {
        public Person Person { get; set; }

        public string OldName { get; set; }
    }
}