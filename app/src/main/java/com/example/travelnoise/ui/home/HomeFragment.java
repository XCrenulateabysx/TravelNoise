package com.example.travelnoise.ui.home;

import android.location.Location;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.LocationModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentHomeBinding;
import com.example.travelnoise.services.ApiClient;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeFragment extends Fragment {

    private FragmentHomeBinding binding;

    private static final String ARG_TITLE = "title";
    private static final String ARG_DESCRIPTION = "description";
    private static final String ARG_IMGURL = "imageURL";


    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("NAV", "HomeFragment loaded");

        ApiService apiService = ApiClient.getClient().create(ApiService.class);
        Log.d("TEST", "onResponse: no response" );

        apiService.getRegions().enqueue(new Callback<List<LocationModel>>()
        {
            @Override
            public void onResponse(Call<List<LocationModel>> call, Response<List<LocationModel>> response)
            {
                Log.d("TEST", "onResponse: no response2" + response.body());

                if(response.isSuccessful() && response.body() != null)
                {
                    List<LocationModel> location = response.body();
                    Log.d("TEST", "onResponse: " + location.get(0).regionName);
                }
            }

            @Override
            public void onFailure(Call<List<LocationModel>> call, Throwable throwable) {

            }
        });
        binding = FragmentHomeBinding.inflate(inflater, container, false);

        binding.imageButton.setOnClickListener(v -> {


            Bundle bundle = new Bundle();

            bundle.putString(ARG_TITLE, "Indie Music");

            bundle.putString(
                    ARG_DESCRIPTION,
                    "Indie music focuses on independent artists."
            );

            bundle.putString(ARG_IMGURL, "http://10.0.2.2:5035/images/WTTTTTTTTTF.png");
            Navigation.findNavController(v)
                    .navigate(R.id.action_navigation_home_to_CityDescriptionFragment, bundle);
        });

        return binding.getRoot();
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}