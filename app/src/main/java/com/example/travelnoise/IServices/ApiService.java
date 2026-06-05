package com.example.travelnoise.IServices;


import com.example.travelnoise.Model.LocationModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ApiService {

    @GET("api/Home/GetRegions")
    Call<List<LocationModel>> getRegions();
}
