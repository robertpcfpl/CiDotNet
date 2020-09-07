import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError} from 'rxjs/operators'
import { throwError} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CalculationService {
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  postCalculationData(data: any): Promise<any> {
    const body =  JSON.stringify(data);
    var headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.baseUrl.concat('api/calculation'), body, { headers } )
      .pipe(catchError((err) => {
        console.log(err);
        return throwError(err);
      })).toPromise();
  }

  getWibor(): Promise<any> {
    return this.http.get(this.baseUrl.concat('api/calculation/GetWiborInterestRate'),{ responseType: 'json' })
      .pipe(catchError((err) => {
        console.log(err);
        return throwError(err);
      })).toPromise();
  }
}
