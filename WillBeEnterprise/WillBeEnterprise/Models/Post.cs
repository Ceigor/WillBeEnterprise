namespace WillBeEnterprise.Models
{
    public class Post
    {
        public long UserId { get; private set; }
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public Post(long userId, long id, string title, string body)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }

        public override string ToString()
        {
            return string.Format("UserId: {0}, Id:{1}, Title:{2}, Body:{3}", UserId, Id, Title, Body);
        }
    }
}
