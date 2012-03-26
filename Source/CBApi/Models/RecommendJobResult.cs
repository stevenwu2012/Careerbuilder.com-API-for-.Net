namespace com.careerbuilder.api.models
{
    public class RecommendJobResult
    {
        public string JobDID { get; set; }
        public string Title { get; set; }
        public double Relevancy { get; set; }
        public Location Location { get; set; }
        public Company Company { get; set; }
        public string JobDetailsURL { get; set; }
        public string JobServiceURL {get; set;}
        public string SimilarJobsURL { get; set; }
    }
}
