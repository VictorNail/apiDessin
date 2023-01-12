namespace apiDessin
{
    public class Dessin: IDessin
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public int _width { get; set; }
        public int _height { get; set; }
        public string _description { get; set; }
        public void Update(Dessin Updatedessin)
        {
            this._id = Updatedessin._id;
            this._name = Updatedessin._name;
            this._width = Updatedessin._width;
            this._height = Updatedessin._height;
            this._description = Updatedessin._description;
        }
    }
}
