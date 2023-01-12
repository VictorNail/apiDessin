namespace apiDessin
{
    public interface IDessin
    {
        int _id { get; set; }
        string _name { get; set; }
        int _width { get; set; }
        int _height { get; set; }
        string _description { get; set; }
        void Update(Dessin updateDessin);

    }

}
