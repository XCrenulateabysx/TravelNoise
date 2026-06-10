package com.example.travelnoise.ui.City;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;

import androidx.fragment.app.Fragment;
import androidx.annotation.NonNull;
import androidx.navigation.Navigation;

import com.bumptech.glide.Glide;
import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.PageGenreModel;
import com.example.travelnoise.Model.PageModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentCityDescriptionBinding;
import com.example.travelnoise.services.ApiClient;
import com.example.travelnoise.services.BundleKeys;
import com.google.android.material.button.MaterialButton;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CityDescriptionFragment extends Fragment {

    private FragmentCityDescriptionBinding binding;



    private String mPageTitle;
    private String mPageDescription;
    private int mPageId;

    private String tempTitle = "Utrecht";



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mPageTitle = getArguments().getString(BundleKeys.ARG_TITLE);
            mPageDescription = getArguments().getString(BundleKeys.ARG_DESCRIPTION);
            mPageId = getArguments().getInt(BundleKeys.ARG_LOCATIONID);
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

        LinearLayout layout = binding.ButtonLayout;


        ApiService apiService = ApiClient.getClient().create(ApiService.class);

        apiService.getPage(mPageId).enqueue(new Callback<PageModel>() {
            @Override
            public void onResponse(Call<PageModel> call, Response<PageModel> response) {
                if(response.isSuccessful() && response.body() != null)
                {
                    PageModel Page = response.body();
                    if(Page.images.get(0).imageURL != null) {
                        Glide.with(CityDescriptionFragment.this)
                                .load(Page.images.get(0).imageURL)
                                .into(binding.imageView5);
                    }
                }
            }

            @Override
            public void onFailure(Call<PageModel> call, Throwable throwable) {
                Log.d("TEST", "onFailure No body home : " + call.toString() + "\n" + throwable.toString());
            }
        });

        apiService.getGenre(mPageId).enqueue(new Callback<List<PageGenreModel>>() {
            @Override
            public void onResponse(Call<List<PageGenreModel>> call, Response<List<PageGenreModel>> response) {
                List<PageGenreModel> Genres = response.body();
                if(!Genres.isEmpty())
                {
                    for(PageGenreModel Genre: Genres)
                    {
                        Log.d("TEST", "onResponse: " + response);
                        MaterialButton button = new MaterialButton(requireContext());
                        button.setText(Genre.genre.genreTitle);

                        button.setOnClickListener(v -> {
                            Bundle bundle = new Bundle();
                            bundle.putInt(BundleKeys.ARG_GENREID,Genre.genreId);
                            bundle.putString(BundleKeys.ARG_GENRETITLE,Genre.genre.genreTitle);
                            bundle.putString(BundleKeys.ARG_GENREDESCRIPTION,Genre.genre.genreDescription);
                            Navigation.findNavController(v)
                                    .navigate(R.id.action_CityDescriptionFragment_to_genreFragment, bundle);
                        });
                        layout.addView(button);
                    }
                    }
            }

            @Override
            public void onFailure(Call<List<PageGenreModel>> call, Throwable throwable) {

            }
        });



        return binding.getRoot();
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}