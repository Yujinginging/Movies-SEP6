import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import * as CanvasJS from '../../assets/canvasjs.min.js';



@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
  

export class MovieComponent implements OnInit {
  public http: HttpClient;
  public baseUrl: string;

  public GetObjFromApi: Array<any> = [];
  //means
  public GetMeans: Array<any> = [];
  //top10
  public GetTop10ByRatings: Array<any> = [];
  public GetTop10ByStars: Array<any> = [];
  public GetTop10ByVotes: Array<any> = [];

  public movieName: any = '';
  //public test: any = '';
  public searchedMovies = [];
  public list: Array<any> = [];
  public ms: Array<any> = [];
  public imgsrc: string = '';

  public ratings = [];
  //
  public yearOne: number = null;
  public yearTwo: number = null;
  public meanRatingByTimePeriod: any = '';

  //loadcharts
  public ratingsToTopTenMovies: Map<string, number>;

  //mean
  public meanVote: any = '';
  public meanRating: any = '';
  public meanStar: any = '';
  //topten
  public GetTopTenMoviesByRatings: Array<any> = [];
  public GetTopTenMoviesByStars: Array<any> = [];
  public GetTopTenMoviesByVotes: Array<any> = [];

  //


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.loadCharts();
    this.loadMeans();
    this.loadTopTen();
  }
  //
  loadMeans() {
    //by ratings
    this.http.get<Map<string, number>>(this.baseUrl + 'MoviesCloud/GetMeanOfRatings').subscribe(result => {
      this.meanRating = result;
    }, error => console.error(error));

    //by votes
    this.http.get<Map<string, number>>(this.baseUrl + 'MoviesCloud/GetMeanOfVotes').subscribe(result => {
      this.meanVote = result;
    }, error => console.error(error));
    //by stars
    this.http.get<Map<string, number>>(this.baseUrl + 'MoviesCloud/GetMeanOfStars').subscribe(result => {
      this.meanStar = result;
    }, error => console.error(error));
  }

  loadTopTen() {
    //by ratings
    this.http.get<Array<string>>(this.baseUrl + 'MoviesCloud/GetTopTenMoviesByRatings').subscribe(result => {
      this.GetTopTenMoviesByRatings = result;
    }, error => console.error(error));
    //by votes
    this.http.get<Array<string>>(this.baseUrl + 'MoviesCloud/GetTopTenMoviesByVotes').subscribe(result => {
      this.GetTopTenMoviesByStars = result;
    }, error => console.error(error));
    //by stars
    this.http.get<Array<string>>(this.baseUrl + 'MoviesCloud/GetTopTenMoviesByStars').subscribe(result => {
      this.GetTopTenMoviesByVotes = result;
    }, error => console.error(error));
  }
  loadCharts() {
    //by ratings 

    let dataPointsRTMovies = [];
    let dataPointsVTMovies = [];
    let dataPointsMovies = [];
    let dataPointsMovies2 = [];
    let dataPointsMovies3 = [];
    let dataPointsST = [];

    let chart = new CanvasJS.Chart("chartContainerRating", {
      animationEnabled: true,
      title: {
        text: "Ratings of  movies"
      },
      axisX: {
        title: "Title",
        interval: 1
      },
      axisY: {
        title: "Ratings"
      },
      data: [{
        type: "column",
        legendText: "RT",
        showInLegend: true,
        dataPoints: dataPointsRTMovies,
        color: "#2E86C1"
      }
     
      ]
    });
    chart.render();
    this.http.get<Map<number, string>>(this.baseUrl + 'MoviesCloud/GetMoviesNames').subscribe(result => {
      Object.keys(result).forEach(function (key) {
        dataPointsMovies.push(result[key])
      });

    }, error => console.error(error));

    this.http.get<Map<number, number>>(this.baseUrl + 'MoviesCloud/GetRatings').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsRTMovies.push({ label: dataPointsMovies[key], y: result[key] })
      });

      chart.render();
    }, error => console.error(error));

    //votes
    let chartVotes = new CanvasJS.Chart("chartContainerVotes", {
      animationEnabled: true,
      title: {
        text: "Votes of movies"
      },
      axisX: {
        title: "Title",
        interval: 1
      },
      axisY: {
        title: "Ratings"
      },
      data: [
      {
        type: "column",
        legendText: "VT",
        showInLegend: true,
        dataPoints: dataPointsVTMovies,
        color: "#C13B2E"
      },

      ]
    });
    chartVotes.render();

    this.http.get<Map<number, string>>(this.baseUrl + 'MoviesCloud/GetMoviesNames').subscribe(result => {
      Object.keys(result).forEach(function (key) {
        dataPointsMovies2.push(result[key])
      });

    }, error => console.error(error));

    this.http.get<Map<number, number>>(this.baseUrl + 'MoviesCloud/GetVotes').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsVTMovies.push({ label: dataPointsMovies2[key], y: result[key] })
      });

      chartVotes.render();
    }, error => console.error(error));

    //by stars
    
    let chartStar = new CanvasJS.Chart("chartContainerStars", {
      animationEnabled: true,
      title: {
        text: "Stars of movies"
      },
      axisX: {
        title: "Title",
        interval: 1
      },
      axisY: {
        title: "Number of stars"
      },
      data: [{
        type: "column",
        legendText: "ST",
        showInLegend: true,
        dataPoints: dataPointsST,
        color: "#2E86C1"
      },
      
      ]
    });
    chartStar.render();
    
    this.http.get<Map<number, string>>(this.baseUrl + 'MoviesCloud/GetMoviesNames').subscribe(result => {
      Object.keys(result).forEach(function (key) {
        dataPointsMovies3.push(result[key])
      });

    }, error => console.error(error));
    this.http.get<Map<number, number>>(this.baseUrl + 'MoviesCloud/GetStars').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsST.push({ label: dataPointsMovies3[key], y: result[key] })
      });

      chartStar.render();
    }, error => console.error(error));
  }

  //
  searchMovie(movieName: string) {
    this.GetObjFromApi = []; //refresh when search again
    this.http.get<string>(this.baseUrl + 'MovieApi/GetObjFromApi/?Title=' + movieName)
      .subscribe(result => {
        this.GetObjFromApi.push(result);
        this.ms.push(result);
      }, error => console.error(error));
    
  }
  add() {
    if (this.ms.length > 0 && this.list.length<10) {
      this.list.push(this.ms[this.ms.length - 1]);
    }
    
  }
  remove(a) { //give value i to a
    this.list.splice(a, 1); //delete
  }
  //searchByTime
  searchByTime(start: number, end: number) {
    let datapointMN = [];
    let datapoitRBTP = [];
    //mean
    this.http.get<Map<string, number>>(this.baseUrl + 'MoviesCloud/GetMeanRatingByTimePeriod/?StartYear=' + start+ '&EndYear=' + end)
      .subscribe(result => {
        this.meanRatingByTimePeriod = result
      }, error => console.error(error));
    //chart
    
    let chartM = new CanvasJS.Chart("chartContainerRatingsByTime", {
      animationEnabled: true,
      title: {
        text: "Ratings of movies by searched time period"
      },
      axisX: {
        title: "Title",
        interval: 1
      },
      axisY: {
        title: "Ratings"
      },
      data: [{
        type: "column",
        legendText: "Movie name",
        showInLegend: true,
        dataPoints: datapoitRBTP,
        color: "#2E86C5"
      },

      ]
    });
    chartM.render();

    this.http.get<Map<number, string>>(this.baseUrl + 'MoviesCloud/GetMovieNamesByTimePeriod/?StartYear=' + start + '&EndYear=' + end)
      .subscribe(result => {
      Object.keys(result).forEach(function (key) {
        datapointMN.push(result[key])
      });

    }, error => console.error(error));

    this.http.get<Map<number, number>>(this.baseUrl + 'MoviesCloud/GetMovieRatingsByTimePeriod/?StartYear=' + start + '&EndYear=' + end)
      .subscribe(result => {

      Object.keys(result).forEach(function (key) {
        datapoitRBTP.push({ label: datapointMN[key], y: result[key] })
      });

      chartM.render();
    }, error => console.error(error));
  
  }

}

interface Rootobject {

  Title: string;
  Year: string;
  Released: string;
  Runtime: string;
  Genre: string;
  Director: string; 
  Writer: string;
  Actors: string;
  Plot: string;
  Language: string;
  Country: string;
  Awards: string;
  Poster: string;
  Ratings: Rating[];
  Metascore: string;
  imdbRating: string;
  imdbVotes: string;
  imdbID: string;
  Type: string;
  DVD: string;
  BoxOffice: string;
  Production: string;
  Website: string;
  Response: string;
}

interface Rating {
  Source: string;
  Value: string;
}
