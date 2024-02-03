/* eslint-disable @typescript-eslint/no-explicit-any */
import { Button } from "@/components/ui/button";
import { motion } from "framer-motion";
import { ArrowDown } from "lucide-react";
import { useEffect, useReducer, useRef } from "react";

const initialState = { currentIndex: 0, direction: 1 };

function reducer(state: any, action: any) {
  switch (action.type) {
    case "UPDATE_INDEX":
      return {
        ...state,
        currentIndex: state.currentIndex + state.direction,
      };
    case "UPDATE_DIRECTION":
      return {
        ...state,
        direction: action.payload.newDirection,
      };
    default:
      return state;
  }
}

const AnchorNav = () => {
  const [state, dispatch] = useReducer(reducer, initialState);
  const navbarHeight = useRef(0);
  useEffect(() => {
    const navbar = document.querySelector("nav");
    if (navbar) {
      const rect = navbar.getBoundingClientRect();
      navbarHeight.current = rect.height;
    }
    const handleScroll = () => {
      const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
      const scrollHeight = document.documentElement.scrollHeight;
      const clientHeight = document.documentElement.clientHeight;

      if (scrollTop <= navbarHeight.current) {
        // At the top of the page
        dispatch({ type: "UPDATE_DIRECTION", payload: { newDirection: 1 } });
      } else if (scrollTop + clientHeight === scrollHeight) {
        // At the bottom of the page
        dispatch({ type: "UPDATE_DIRECTION", payload: { newDirection: -1 } });
      }
    };

    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, []);

  const handleClick = () => {
    const anchors = Array.from(
      document.querySelectorAll('[data-name]:not([data-name=""])'),
    ) as HTMLElement[];
    if (anchors.length === 0) return;

    const newIndex = state.currentIndex + state.direction;

    // Change direction if at the next start or end
    if (newIndex < 0 || newIndex >= anchors.length) {
      const newDirection = -state.direction;
      dispatch({ type: "UPDATE_DIRECTION", payload: { newDirection } });
    }

    dispatch({ type: "UPDATE_INDEX" });

    // Scroll to the new anchor if it exists
    if (anchors[state.currentIndex]) {
      anchors[state.currentIndex].scrollIntoView({ behavior: "smooth" });
    }
  };

  return (
    <Button variant="outline" size="icon" className="fixed right-6 bottom-6" onClick={handleClick}>
      <motion.span
        animate={{ rotate: state.direction === 1 ? 0 : 180 }}
        transition={{ duration: 0.2, delay: 0.25 }}
      >
        <ArrowDown className="h-6 w-6" />
      </motion.span>
    </Button>
  );
};

export default AnchorNav;
