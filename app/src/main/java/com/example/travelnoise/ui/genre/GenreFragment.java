package com.example.travelnoise.ui.genre;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentGenreBinding;
import com.example.travelnoise.services.BundleKeys;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link GenreFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class GenreFragment extends Fragment {
    private FragmentGenreBinding binding;


    private int mGenreId;
    private String mGenreTitle;
    private String mGenreDescription;

    public GenreFragment() {
        // Required empty public constructor
    }



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mGenreId = getArguments().getInt(BundleKeys.ARG_GENREID);
            mGenreTitle = getArguments().getString(BundleKeys.ARG_GENRETITLE);
            mGenreDescription = getArguments().getString(BundleKeys.ARG_GENREDESCRIPTION);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentGenreBinding.inflate(inflater, container, false);
        Log.d("TEST", "onCreateView: " + mGenreId);
        // Inflate the layout for this fragment

        binding.GenreInfoTitle.setText(mGenreTitle);
        binding.GenreDescription.setText(mGenreDescription);

        binding.chordsBtn.setOnClickListener(v ->
                navigateToTheory(v, mGenreId, "Chords"));

        binding.harmonyBtn.setOnClickListener(v ->
                navigateToTheory(v, mGenreId, "Harmony"));

        binding.instrumentsBtn.setOnClickListener(v ->
                navigateToTheory(v, mGenreId, "Instruments"));

        binding.rhythmBtn.setOnClickListener(v ->
                navigateToTheory(v, mGenreId, "Rhythm"));
        return binding.getRoot();
    }
    private void navigateToTheory(View v, int genreId, String category)
    {
        Bundle bundle = new Bundle();
        bundle.putInt(BundleKeys.ARG_GENREID, genreId);
        bundle.putString(BundleKeys.ARG_CATEGORY, category);

        Navigation.findNavController(v)
                .navigate(R.id.action_genreFragment_to_theoryFragment, bundle);
    }
}