namespace Poq.Application.Parameter
{
    public class ProductParams
    {
        /// <summary>
        /// The max price 
        /// </summary>
        /// <example>999.9</example>
        public double MaxPrice { get; set; } = 999999999999;

        /// <summary>
        /// The keywords 
        /// </summary>
        /// <example>blue,red</example>
        public string Highlights { get; set; } = "";

        /// <summary>
        /// The sizes the product is available in
        /// </summary>
        /// <example>medium</example>
        public string Size { get; set; } = "";


    }
}
