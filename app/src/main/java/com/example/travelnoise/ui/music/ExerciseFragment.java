package com.example.travelnoise.ui.music;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentExerciseBinding;
import com.example.travelnoise.databinding.FragmentTheoryBinding;
import com.example.travelnoise.services.ApiClient;
import com.example.travelnoise.services.BundleKeys;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ExerciseFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ExerciseFragment extends Fragment {



    // TODO: Rename and change types of parameters
    private int mGenreId;
    private String mCategory;
    private FragmentExerciseBinding binding;

    public ExerciseFragment() {
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
        binding = FragmentExerciseBinding.inflate(inflater, container, false);

        showExercise(mCategory);

        // Inflate the layout for this fragment
        return binding.getRoot();
    }

    private void showExercise(String type) {

        // first hide everything
        binding.HarmonyExercise.setVisibility(View.GONE);
        binding.ChordExercise.setVisibility(View.GONE);
        binding.RythmExercise.setVisibility(View.GONE);
        binding.InstrumentsExercise.setVisibility(View.GONE);

        switch (type) {

            case "Harmony":
                binding.HarmonyExercise.setVisibility(View.VISIBLE);
                break;

            case "Chords":
                binding.ChordExercise.setVisibility(View.VISIBLE);
                break;

            case "Rhythm":
                binding.RythmExercise.setVisibility(View.VISIBLE);
                break;

            case "Instruments":
                binding.InstrumentsExercise.setVisibility(View.VISIBLE);
                break;

            default:
                // fallback (optional)
                binding.HarmonyExercise.setVisibility(View.GONE);
                binding.ChordExercise.setVisibility(View.GONE);
                binding.RythmExercise.setVisibility(View.GONE);
                binding.InstrumentsExercise.setVisibility(View.GONE);
                break;
        }
    }

    private void fillExerciseData(String category)
    {
        ApiService apiService = ApiClient.getClient().create(ApiService.class);
    }
}