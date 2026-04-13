package com.example.travelnoise;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import androidx.fragment.app.Fragment;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.Navigation;

import com.example.travelnoise.databinding.FragmentHomeBinding;
import com.example.travelnoise.databinding.FragmentScrollingIntroLocationBinding;
import com.example.travelnoise.ui.home.HomeViewModel;
import com.google.android.material.bottomnavigation.BottomNavigationView;

public class ScrollingIntroLocationFragment extends Fragment {

    private FragmentScrollingIntroLocationBinding binding;

    private String tempDescription = "Utrecht is known for its diverse music scene rather than one specific genre. The city has a strong presence in indie and alternative music, along with electronic, jazz, and experimental styles. Venues like TivoliVredenburg and festivals such as Le Guess Who? contribute to its reputation as a hub for live music and emerging talent.";


    private String tempTitle = "Utrecht";

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {

        binding = FragmentScrollingIntroLocationBinding.inflate(inflater, container, false);
        binding.Title.setText(tempTitle);
        binding.Description.setText(tempDescription);

        return binding.getRoot();
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}