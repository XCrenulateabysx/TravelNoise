package com.example.travelnoise.ui.City;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import androidx.fragment.app.Fragment;
import androidx.annotation.NonNull;
import androidx.navigation.Navigation;

import com.bumptech.glide.Glide;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentCityDescriptionBinding;
import com.google.android.material.button.MaterialButton;

public class CityDescriptionFragment extends Fragment {

    private FragmentCityDescriptionBinding binding;

    private static final String ARG_TITLE = "title";
    private static final String ARG_DESCRIPTION = "description";
    private static final String ARG_IMGURL = "imageURL";

    private String mGenreTitle;
    private String mGenreDescription;
    private String mGenreURL;

    private String tempTitle = "Utrecht";



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mGenreTitle = getArguments().getString(ARG_TITLE);
            mGenreDescription = getArguments().getString(ARG_DESCRIPTION);
            mGenreURL = getArguments().getString(ARG_IMGURL);
        }

    }
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {
        //Text and image binding
        binding = FragmentCityDescriptionBinding.inflate(inflater, container, false);
        binding.Title.setText(mGenreTitle);
        binding.Description.setText(mGenreDescription);


        MaterialButton testbutton = new MaterialButton(requireContext());
        testbutton.setText("Test dynamic button");

        binding.ButtonLayout.addView(testbutton);
        Glide.with(this)
                .load(mGenreURL)
                .into(binding.imageView5);

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