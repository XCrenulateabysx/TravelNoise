package com.example.travelnoise.ui.City;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.fragment.app.Fragment;
import androidx.annotation.NonNull;
import androidx.navigation.Navigation;

import com.bumptech.glide.Glide;
import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.PageModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentCityDescriptionBinding;
import com.example.travelnoise.services.ApiClient;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CityDescriptionFragment extends Fragment {

    private FragmentCityDescriptionBinding binding;

    private static final String ARG_TITLE = "title";
    private static final String ARG_DESCRIPTION = "description";
    private static final String ARG_LOCATIONID = "LocationId";

    private String mPageTitle;
    private String mPageDescription;
    private int mPageId;

    private String tempTitle = "Utrecht";



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mPageTitle = getArguments().getString(ARG_TITLE);
            mPageDescription = getArguments().getString(ARG_DESCRIPTION);
            mPageId = getArguments().getInt(ARG_LOCATIONID);
        }

    }
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {
        //Text and image binding
        binding = FragmentCityDescriptionBinding.inflate(inflater, container, false);
        binding.Title.setText(mPageTitle);
        binding.Description.setText(mPageDescription);



        ApiService apiService = ApiClient.getClient().create(ApiService.class);

        apiService.getPage(mPageId).enqueue(new Callback<PageModel>() {
            @Override
            public void onResponse(Call<PageModel> call, Response<PageModel> response) {
                if(response.isSuccessful() && response.body() != null)
                {
                    PageModel Page = response.body();
                    Log.d("TEST", "onResponse imageurl: " + response.message());
                    Log.d("TEST", "onResponse imageurl: " + Page.images.imageURL);
                    Log.d("TEST", "onResponse imageurl: " + Page.images.id);
                    Log.d("TEST", "onResponse imageurl: " + Page.id);
                    if(Page.images.imageURL != null) {
                        Glide.with(CityDescriptionFragment.this)
                                .load(Page.images.imageURL)
                                .into(binding.imageView5);
                    }
                }
            }

            @Override
            public void onFailure(Call<PageModel> call, Throwable throwable) {
                Log.d("TEST", "onFailure No body home : " + call.toString() + "\n" + throwable.toString());
            }
        });

        binding.jazz.setOnClickListener(v -> {
            Navigation.findNavController(v)
                    .navigate(R.id.action_scrollingIntroLocationFragment_to_jazzFragment);
        });
        binding.indie.setOnClickListener(v -> {
            Navigation.findNavController(v)
                    .navigate(R.id.action_scrollingIntroLocationFragment_to_indieFragment);
        });

        return binding.getRoot();
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}