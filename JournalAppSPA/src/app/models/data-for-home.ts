
import { LatestNews } from "./latest-news";
import { NewsForHome } from "./news-for-home";

export interface DataForHome {
  importantNews: NewsForHome[];
  sectionPolandNews: NewsForHome[];
  sectionWorldNews: NewsForHome[];
  sectionPolicyNews: NewsForHome[];
  sectionBusinessNews: NewsForHome[];
  sectionSportNews: NewsForHome[];
  latestNews: LatestNews[];
}
