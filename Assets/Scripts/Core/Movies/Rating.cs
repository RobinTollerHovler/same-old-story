
namespace Core.Movies {
    
    public class Rating {

        private readonly float score;

        public Rating(float score) {
            this.score = score;
        }

        public int Stars() {
            return (int)(score / 2);
        }
    }
    
}