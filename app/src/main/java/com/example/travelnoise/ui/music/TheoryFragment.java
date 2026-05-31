package com.example.travelnoise.ui.music;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.travelnoise.R;

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

    public TheoryFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param theoryTitle Parameter 1.
     * @param theoryDescription Parameter 2.
     * @return A new instance of fragment TheoryFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static TheoryFragment newInstance(String theoryTitle, String theoryDescription, String theoryImageURL) {
        TheoryFragment fragment = new TheoryFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, theoryTitle);
        args.putString(ARG_PARAM2, theoryDescription);
        args.putString(ARG_PARAM3, theoryImageURL);
        fragment.setArguments(args);
        return fragment;
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
        return inflater.inflate(R.layout.fragment_theory, container, false);
    }
}