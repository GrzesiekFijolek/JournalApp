import { NewsForDetails } from "./news-for-details";
import { LatestNews } from "./latest-news";

export interface DataForNewsDetails {
  newsForDetails: NewsForDetails,
  newsForOtherInfos: LatestNews[]
}
