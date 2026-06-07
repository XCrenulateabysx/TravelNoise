package com.example.travelnoise.IServices;


import com.example.travelnoise.Model.LocationModel;
import com.example.travelnoise.Model.PageModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface ApiService {

    @GET("api/Home/GetRegions")
    Call<List<LocationModel>> getRegions();

    @GET("api/Page/GetPage/{id}")
    Call<PageModel> getPage(@Path("id") int id);
}
