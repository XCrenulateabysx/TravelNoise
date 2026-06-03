package com.example.travelnoise.ui.home;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentHomeBinding;

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