import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
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
  public GetMeans: Array<any> = [];

  public movieName: any = '';
  //public test: any = '';
  public searchedMovies = [];
  public list: Array<any> = [];
  public ms: Array<any> = [];
  public imgsrc: string = '';

  public ratings = [];
  public yearOne: number = null;
  public yearTwo: number = null;

  //loadcharts
  public ratingsToTopTenMovies: Map<string, number>;



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
    //by votes
    //by stars
  }

  loadTopTen() {
    //by ratings
    //by votes
    //by stars
  }
  loadCharts() {
    //by ratings & votes

    this.http.get<Map<string, number>>(this.baseUrl + '').subscribe(result => {
      this.ratingsToTopTenMovies = result;
    }, error => console.error(error));

    let dataPointsRTMovies = [];
    let dataPointsVTMovies = [];

    let chart = new CanvasJS.Chart("chartContainerRatingAndVote", {
      animationEnabled: true,
      title: {
        text: "Ratings of TOP10 movies"
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
      },
      {
        type: "column",
        legendText: "VT",
        showInLegend: true,
        dataPoints: dataPointsVTMovies,
        color: "#C13B2E"
      },
     
      ]
    });
    chart.render();

    this.http.get<Map<string, number>>(this.baseUrl + '').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsRTMovies.push({ label: key, y: result[key] })
      });

      chart.render();
    }, error => console.error(error));
    this.http.get<Map<string, number>>(this.baseUrl + '').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsVTMovies.push({ label: key, y: result[key] })
      });

      chart.render();
    }, error => console.error(error));

    //by stars
    let dataPointsST = [];
    let chartStar = new CanvasJS.Chart("chartContainerStars", {
      animationEnabled: true,
      title: {
        text: "Stars of TOP10 movies"
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
        legendText: "JFK",
        showInLegend: true,
        dataPoints: dataPointsST,
        color: "#2E86C1"
      },
      
      ]
    });
    chartStar.render();

    this.http.get<Map<string, number>>(this.baseUrl + 'api/Nycflights/FlightsToTopTenDestinationsFromJFK').subscribe(result => {

      Object.keys(result).forEach(function (key) {
        dataPointsST.push({ label: key, y: result[key] })
      });

      chartStar.render();
    }, error => console.error(error));
  }

  //
  searchMovie(movieName: string) {
    this.GetObjFromApi = []; //refresh when search again
    this.http.get<string>(this.baseUrl + 'MovieApi/GetObjFromApi/?Title=' + movieName)
      .subscribe(result => {
        //this.ms.push(result);
        this.GetObjFromApi.push(result);
        this.ms.push(result);
      }, error => console.error(error));
    /*this.http.get<string>(this.baseUrl + 'MovieApi/GetImg/?Title=' + movieName)
      .subscribe(result => {
        this.imgsrc=result;
      }, error => console.error(error));*/
    
  }
  add() {
    if (this.ms.length > 0) {
      this.list.push(this.ms[this.ms.length - 1]);
    }
    
  }
  remove(a) { //give value i to a
    this.list.splice(a, 1); //delete
  }
  searchByTime() {
    /*this.http.get<string[]>(this.baseUrl + 'api/SepSixMovies/MoviesPerTimeAndRating').subscribe(result => {
      this.MoviesPerTimeAndRating = result;
    }, error => console.error(error));*/

    //this.ratings.push(this.yearOne, this.yearTwo);
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
