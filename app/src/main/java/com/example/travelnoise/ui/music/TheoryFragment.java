package com.example.travelnoise.ui.music;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.bumptech.glide.Glide;
import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.TheoryPageModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentTheoryBinding;
import com.example.travelnoise.services.ApiClient;
import com.example.travelnoise.services.BundleKeys;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link TheoryFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class TheoryFragment extends Fragment {


    private int mGenreId;
    private String mCategory;

    private FragmentTheoryBinding binding;

    public TheoryFragment() {
        // Required empty public constructor
    }



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mGenreId = getArguments().getInt(BundleKeys.ARG_GENREID);
            mCategory = getArguments().getString(BundleKeys.ARG_CATEGORY);

        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        ApiService apiService = ApiClient.getClient().create(ApiService.class);
        binding = FragmentTheoryBinding.inflate(inflater, container, false);

        apiService.getPage(mGenreId, mCategory).enqueue(new Callback<TheoryPageModel>() {
            @Override
            public void onResponse(Call<TheoryPageModel> call, Response<TheoryPageModel> response) {
                TheoryPageModel pageInfo = response.body();

                binding.TheoryTitle.setText(pageInfo.title);
                binding.TheoryDescription.setText(pageInfo.description);

                Glide.with(TheoryFragment.this)
                        .load(pageInfo.images.get(0).imageURL)
                        .into(binding.TheoryPreviewImage);

            }

            @Override
            public void onFailure(Call<TheoryPageModel> call, Throwable throwable) {

            }
        });

        binding.startPracticeBtn.setOnClickListener(v ->
        {
            Bundle bundle = new Bundle();
            bundle.putInt(BundleKeys.ARG_GENREID, mGenreId);
            bundle.putString(BundleKeys.ARG_CATEGORY, mCategory);
            Navigation.findNavController(v)
                    .navigate(R.id.action_theoryFragment_to_exerciseFragment, bundle);
        });





        return binding.getRoot();
    }
}