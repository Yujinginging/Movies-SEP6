import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

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
  //save data temporarily
  private myRequest?: Observable<Array<any>>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    /*this.http.get<Array<any>>(this.baseUrl + 'MovieApi/GetTopTenList').subscribe(data => {
      this.list.push(data);
    }, error => console.error(error));*/
  }
  //TODO:acess "cached" req
/*  public doRequest(): Observable<Array<any>> {
    if (!this.myRequest) {
      this.myRequest = this.http.get(this.baseUrl + 'savedList').pipe(
      shareReplay(1))
    }
    return this.myRequest;
  }*/
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
    this.list.push(this.ms[this.ms.length - 1]);
    
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
