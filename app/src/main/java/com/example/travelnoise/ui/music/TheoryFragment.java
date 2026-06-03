package com.example.travelnoise.ui.music;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.bumptech.glide.Glide;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentIndieBinding;
import com.example.travelnoise.databinding.FragmentTheoryBinding;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link TheoryFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class TheoryFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "title";
    private static final String ARG_PARAM2 = "description";
    private static final String ARG_PARAM3 = "imageURL";

    // TODO: Rename and change types of parameters
    private String mTheoryTitle;
    private String mTheoryDescription;
    private String mTheoryImageURL;

    private FragmentTheoryBinding binding;

    public TheoryFragment() {
        // Required empty public constructor
    }



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mTheoryTitle = getArguments().getString(ARG_PARAM1);
            mTheoryDescription = getArguments().getString(ARG_PARAM2);
            mTheoryImageURL = getArguments().getString(ARG_PARAM3);
        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentTheoryBinding.inflate(inflater, container, false);

        binding.TheoryTitle.setText(mTheoryTitle);
        binding.TheoryDescription.setText(mTheoryDescription);

        String url = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png";
        Glide.with(this)
                .load(url)
                .into(binding.TheoryPreviewImage);


        return binding.getRoot();
    }
}